using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonsUserTable.APiDtos.Request.RolePage;
using NonsUserTable.APiDtos.Respose;
using NonsUserTable.APiDtos.Respose.RolePage;
using NonsUserTable.Entites;
using NonsUserTable.IUnitOfWork;

namespace NonsUserTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePagesController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        public RolePagesController(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RolePageReqC_ApiDto createModel)
        {
            var response = new BaseControlResponse<RolePageResApiDto>();

            var itemToCreate = _mapper.Map<RolePage>(createModel);
            var createdItem = await _uow.rolePageRepo.CreateAsync(itemToCreate);

            return Ok(response);
        }

    }
}
