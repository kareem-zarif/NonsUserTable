using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonsUserTable.APiDtos.Request.Page;
using NonsUserTable.APiDtos.Respose;
using NonsUserTable.APiDtos.Respose.Page;
using NonsUserTable.Entites;
using NonsUserTable.Enums;
using NonsUserTable.IUnitOfWork;
using NonsUserTable.Utilites;

namespace NonsUserTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public PagesController(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PageReqC_ApiDto createModel)
        {
            var response = new BaseControlResponse<PageResApiDto>();
            try
            {
                var pageToCreate = _mapper.Map<Page>(createModel);
                var createdPage = await _uow.pageRepo.CreateAsync(pageToCreate);
                createdPage.IsAlive = true;
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving changes in db");
                var responseDto = _mapper.Map<PageResApiDto>(createdPage);

                response.ResponseResult = RespinseResultEnum.Success;

                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<PageResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error creating a page : {createModel.Name} ", ex);
            }
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = new BaseControlResponse<PageResApiDto>();
            try
            {
                var foundPage = await _uow.pageRepo.GetAsync(id);
                var responseDto = _mapper.Map<PageResApiDto>(foundPage);

                response.ResponseResult = RespinseResultEnum.Success;

                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<PageResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting page with id : {id}", ex);
            }
            return Ok(response);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAsync()
        {
            var response = new BaseControlResponse<List<PageResApiDto>>();
            try
            {
                var foundList = await _uow.pageRepo.GetAsync();
                var listDto = _mapper.Map<List<PageResApiDto>>(foundList);
                response.ResponseResult = RespinseResultEnum.Success;

                response.Data = listDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<List<PageResApiDto>>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error getting all Pages", ex);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(PageReqU_ApiDto updateModel)
        {
            var response = new BaseControlResponse<PageResApiDto>();
            try
            {
                var pageToUpdate = _mapper.Map<Page>(updateModel);
                var updatedPage = await _uow.pageRepo.UpdateAsync(pageToUpdate);
                updatedPage.IsAlive = true;
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving in db");
                var responseDto = _mapper.Map<PageResApiDto>(updatedPage);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<PageResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error updating page : {updateModel.Name}", ex);
            }
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsyc(Guid id)
        {
            var response = new BaseControlResponse<PageResApiDto>();
            try
            {
                var deletedPage = await _uow.pageRepo.DeleteAsync(id);
                deletedPage.IsAlive = false;
                int savedChanges = await _uow.CompleteAsync();
                if (savedChanges == 0)
                    throw new Exception($"error saving in db");
                var responseDto = _mapper.Map<PageResApiDto>(deletedPage);

                response.ResponseResult = RespinseResultEnum.Success;
                response.Data = responseDto;
            }
            catch (Exception ex)
            {
                response = new ErrorCatcherUtlity<PageResApiDto>().CatchErrorAndReturnBaseControolerResponse(Guid.NewGuid(), $"error deleting a page : {id}", ex);
            }
            return Ok(response);
        }

    }
}
