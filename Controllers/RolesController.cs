namespace NonsUserTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public RolesController(IUOW iow, IMapper mapper)
        {
            _uow = iow;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoleReqC_ApiDto roleReq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new BaseControlResponse<RoleResApiDto>();
            try
            {
                var roleToCreate = _mapper.Map<Role>(roleReq);
                var cretedRole = await _uow.roleRepo.CreateAsync(roleToCreate);
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving created Role in db");
                var responseDto = _mapper.Map<RoleResApiDto>(cretedRole);
                responseDto.IsAlive = true;

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<RoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error creating Role : {roleReq.Name}", ex);
            }
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = new BaseControlResponse<RoleResApiDto>();
            try
            {
                var foundRole = await _uow.roleRepo.GetAsync(id);
                var responseDto = _mapper.Map<RoleResApiDto>(foundRole);
                response.Data = responseDto;
                response.ResponseResult = RespinseResultEnum.Success;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<RoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting Role : {id}", ex);
            }

            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = new BaseControlResponse<List<RoleResApiDto>>();
            try
            {
                var foundList = await _uow.roleRepo.GetAsync();
                var listDto = _mapper.Map<List<RoleResApiDto>>(foundList);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = listDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<RoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error gatting all roles", ex);
            }
            return Ok(response);
        }

        [HttpGet("{partOfName}")]
        public async Task<IActionResult> GetAsync(string partOfName)
        {
            var response = new BaseControlResponse<List<RoleResApiDto>>();
            try
            {
                var foundList = await _uow.roleRepo.GetAsync(x => x.Name.Contains(partOfName.ToUpper()));
                var listDtos = _mapper.Map<List<RoleResApiDto>>(foundList);
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = listDtos;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<RoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting all roles contain : {partOfName}", ex);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(RoleReqU_ApiDto updateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new BaseControlResponse<RoleResApiDto>();
            try
            {
                var roleToUpdate = _mapper.Map<Role>(updateModel);
                var updatedRole = await _uow.roleRepo.UpdateAsync(roleToUpdate);
                var savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error updating Role in db");
                var roleDto = _mapper.Map<RoleResApiDto>(updatedRole);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = roleDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<RoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error updating Role : {updateModel.Id}", ex);
            }
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseControlResponse<RoleResApiDto>();
            try
            {
                var deleteRole = await _uow.roleRepo.DeleteAsync(id);
                var saveChanges = await _uow.CompleteAsync();
                if (saveChanges == 0)
                    throw new Exception($"error deleting a Role from db");
                var responseDto = _mapper.Map<RoleResApiDto>(deleteRole);
                responseDto.IsAlive = false;
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<RoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error deleting a Role : {id}", ex);
            }
            return Ok(response);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteAsync(string name)
        {
            var response = new BaseControlResponse<List<RoleResApiDto>>();
            try
            {
                var foundList = await _uow.roleRepo.GetAsync(x => x.Name.Equals(name.ToUpper()));
                foreach (var role in foundList)
                {
                    var deletedRole = await _uow.roleRepo.DeleteAsync(role.Id);
                    deletedRole.IsAlive = false;
                }
                var savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error deleting roles with name : {name} from db");
                var responseDtoList = _mapper.Map<List<RoleResApiDto>>(foundList);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDtoList;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<RoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error deleting roles with name : {name}", ex);
            }

            return Ok(response);
        }

    }
}
