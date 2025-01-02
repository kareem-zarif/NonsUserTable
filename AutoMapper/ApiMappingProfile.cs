using AutoMapper;
using NonsUserTable.APiDtos.Request.Page;
using NonsUserTable.APiDtos.Request.Role;
using NonsUserTable.APiDtos.Request.RolePage;
using NonsUserTable.APiDtos.Request.User;
using NonsUserTable.APiDtos.Request.UserRole;
using NonsUserTable.APiDtos.Respose.Page;
using NonsUserTable.APiDtos.Respose.Role;
using NonsUserTable.APiDtos.Respose.RolePage;
using NonsUserTable.APiDtos.Respose.User;
using NonsUserTable.APiDtos.Respose.UserRole;
using NonsUserTable.Entites;

namespace NonsUserTable.AutoMapper
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<UserReqC_ApiDto, User>().ReverseMap();
            CreateMap<UserReqU_ApiDto, User>().ReverseMap();
            CreateMap<UserResApiDto, User>().ReverseMap();

            CreateMap<RoleReqC_ApiDto, Role>().ReverseMap();
            CreateMap<RoleReqU_ApiDto, Role>().ReverseMap();
            CreateMap<RoleResApiDto, Role>().ReverseMap();

            CreateMap<UserRoleReqC_ApiDto, UserRole>().ReverseMap();
            CreateMap<UserRoleReqU_ApiDto, UserRole>().ReverseMap();
            CreateMap<UserRoleResApiDto, UserRole>().ReverseMap();

            CreateMap<PageReqC_ApiDto, Page>().ReverseMap();
            CreateMap<PageReqU_ApiDto, Page>().ReverseMap();
            CreateMap<PageResApiDto, Page>().ReverseMap();

            CreateMap<RolePageReqC_ApiDto, RolePage>().ReverseMap();
            CreateMap<RolePageReqU_ApiDto, RolePage>().ReverseMap();
            CreateMap<RolePageResApiDto, RolePage>().ReverseMap();
        }
    }
}
