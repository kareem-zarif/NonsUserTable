using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.IRepos;
using NonsUserTable.IUnitOfWork;
using NonsUserTable.Repos;
using NonsUserTable.UnitOfWork;

namespace NonsUserTable.IOC
{
    public static class Extensions
    {
        public static IServiceCollection ConfigSingleLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UserTableDBContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("DefaultConn"))
                );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IUOW), typeof(UOW));
            services.AddScoped(typeof(IBaseRepo<,>), typeof(BaseRepo<,>));
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRoleRepo, UserRoleRepo>();
            services.AddScoped<IPageRepo, PageRepo>();
            services.AddScoped<IRolePageRepo, RolePageRepo>();

            return services;
        }
    }
}
