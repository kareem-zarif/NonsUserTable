using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonsUserTable.APiDtos.Request.UserRole;
using NonsUserTable.APiDtos.Respose;
using NonsUserTable.APiDtos.Respose.UserRole;
using NonsUserTable.Entites;
using NonsUserTable.Enums;
using NonsUserTable.IUnitOfWork;
using NonsUserTable.Utilites;

namespace NonsUserTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public UserRolesController(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserRoleReqC_ApiDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new BaseControlResponse<UserRoleResApiDto>();
            try
            {
                var itemToCreate = _mapper.Map<UserRole>(createDto);
                var createdItem = await _uow.userRoleRepo.CreateAsync(itemToCreate);
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving changes in db");
                var responseDto = _mapper.Map<UserRoleResApiDto>(createdItem);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserRoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error creating new User_role", ex);
            }

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = new BaseControlResponse<UserRoleResApiDto>();
            try
            {
                var foundItem = await _uow.userRoleRepo.GetAsync(id);
                var responseDto = _mapper.Map<UserRoleResApiDto>(foundItem);
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserRoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting user_role with id : {id}", ex);
            }
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = new BaseControlResponse<List<UserRoleResApiDto>>();
            try
            {
                var foundList = await _uow.userRoleRepo.GetAsync();
                var listDto = _mapper.Map<List<UserRoleResApiDto>>(foundList);
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = listDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<UserRoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting all User_Role", ex);
            }
            return Ok(response);
        }

        [HttpGet("GetAllRoles/{userId:guid}")]
        public async Task<IActionResult> GetAllRolesAsync(Guid userId)
        {
            var response = new BaseControlResponse<List<UserRoleResApiDto>>();
            try
            {
                var foundList = await _uow.userRoleRepo.GetAsync(x => x.UserId.Equals(userId));
                var listDto = _mapper.Map<List<UserRoleResApiDto>>(foundList);
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = listDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<UserRoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting all roles assoisated with user id : {userId}", ex);
            }
            return Ok(response);
        }

        [HttpGet("GetAllUsers/{roleId}")]
        public async Task<IActionResult> GetAllUsersAsync(Guid roleId)
        {
            var response = new BaseControlResponse<List<UserRoleResApiDto>>();
            try
            {
                var foundList = await _uow.userRoleRepo.GetAsync(x => x.RoleId.Equals(roleId));
                var listDto = _mapper.Map<List<UserRoleResApiDto>>(foundList);
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = listDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<UserRoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting all users assosiated with Role : {roleId}", ex);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserRoleReqU_ApiDto updateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new BaseControlResponse<UserRoleResApiDto>();
            try
            {
                var itemToUpdate = _mapper.Map<UserRole>(updateModel);
                var updatedItem = await _uow.userRoleRepo.UpdateAsync(itemToUpdate);
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving changes in db");
                var responseDto = _mapper.Map<UserRoleResApiDto>(updatedItem);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserRoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error updating user_role with id  : {updateModel.Id}", ex);
            }

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseControlResponse<UserRoleResApiDto>();
            try
            {
                var deletedItem = await _uow.userRoleRepo.DeleteAsync(id);
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving User_role with id : {id}");
                var responseDto = _mapper.Map<UserRoleResApiDto>(deletedItem);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserRoleResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error deleting User_role with id : {id}", ex);
            }

            return Ok(response);
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAsync()
        {
            var response = new BaseControlResponse<List<UserRoleResApiDto>>();
            try
            {
                var foundList = await _uow.userRoleRepo.GetAsync();
                var responseListDto = new List<UserRoleResApiDto>();
                foreach (var item in foundList)
                {
                    var deletedItem = await _uow.userRoleRepo.DeleteAsync(item.Id);
                    _uow.CompleteAsync();
                    var mappedResponse = _mapper.Map<UserRoleResApiDto>(item);
                    responseListDto.Add(mappedResponse);
                }
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseListDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<UserRoleResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error deleting all User_Role", ex);
            }

            return Ok(response);
        }
    }
}
