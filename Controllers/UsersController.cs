using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonsUserTable.APiDtos.Request.User;
using NonsUserTable.APiDtos.Respose;
using NonsUserTable.APiDtos.Respose.User;
using NonsUserTable.Entites;
using NonsUserTable.Enums;
using NonsUserTable.IUnitOfWork;
using NonsUserTable.Utilites;

namespace NonsUserTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public UsersController(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateAsync([FromBody] UserReqC_ApiDto createModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var respone = new BaseControlResponse<UserResApiDto>();
            try
            {
                var itemToCreate = _mapper.Map<User>(createModel);
                var CreatedItem = await _uow.userRepo.CreateAsync(itemToCreate);
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                {
                    throw new Exception($"error when saving in database");
                }
                var resonseDto = _mapper.Map<UserResApiDto>(CreatedItem);
                respone.ResponseResult = RespinseResultEnum.Success;
                respone.Data = resonseDto;
            }
            catch (Exception ex)
            {
                respone = new ErrorCatcherUtlity<UserResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error creating User : {createModel.UserName} : {createModel.UserEmail}", ex);
            }
            return Ok(respone);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetAsync([FromBody] UserReqG_ApiDto getModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new BaseControlResponse<UserResApiDto>();
            try
            {
                var foundItem = await _uow.userRepo.GetAsyncByEmail(getModel.UserEmail);
                var responseDto = _mapper.Map<UserResApiDto>(foundItem);
                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"Error getting User : {getModel.UserEmail}", ex);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = new BaseControlResponse<UserResApiDto>();
            try
            {
                var founduser = await _uow.userRepo.GetAsync(id);
                var responseDto = _mapper.Map<UserResApiDto>(founduser);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting User ", ex);
            }

            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = new BaseControlResponse<List<UserResApiDto>>();
            try
            {
                var foundList = await _uow.userRepo.GetAsync();
                var responseDto = _mapper.Map<List<UserResApiDto>>(foundList);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<UserResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting all Users", ex);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserReqU_ApiDto updateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new BaseControlResponse<UserResApiDto>();
            try
            {
                var userToUpdate = _mapper.Map<User>(updateModel);
                var updatedUser = await _uow.userRepo.UpdateAsync(userToUpdate);
                updatedUser.IsModified = true;
                int savesChanges = await _uow.CompleteAsync();
                if (savesChanges == 0)
                    throw new Exception($"error when saving in database");
                var responseDto = _mapper.Map<UserResApiDto>(updatedUser);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error updating user : {updateModel.UserEmail}", ex);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseControlResponse<UserResApiDto>();
            try
            {
                var deletedUser = await _uow.userRepo.DeleteAsync(id);
                deletedUser.IsDeleted = true;
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error deleting in db : {id}");
                var responseDto = _mapper.Map<UserResApiDto>(deletedUser);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<UserResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error when deleting User : {id}", ex);
            }

            return Ok(response);
        }


    }
}
