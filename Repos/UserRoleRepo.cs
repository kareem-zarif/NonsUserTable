using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.Entites;
using NonsUserTable.IRepos;

namespace NonsUserTable.Repos
{
    public class UserRoleRepo : BaseRepo<UserRole, Guid>, IUserRoleRepo
    {
        private readonly UserTableDBContext _dbContext;
        public UserRoleRepo(UserTableDBContext context) : base(context)
        {
            _dbContext = context;
        }
        public override async Task<UserRole> CreateAsync(UserRole entity)
        {
            var existUser = await _dbContext.Users.FindAsync(entity.UserId);
            var existRole = await _dbContext.Roles.FindAsync(entity.RoleId);
            if (existUser == null || existRole == null)
                throw new Exception($"not found user : {entity.UserId} or Role : {entity.RoleId}");

            var existUserRole = await _dbContext.UserRoles.AsNoTracking().FirstOrDefaultAsync(x =>
                x.UserId.Equals(entity.UserId) &&
                x.RoleId.Equals(entity.RoleId)
            );

            if (existUserRole is not null)
                throw new Exception($"this userRole  is already Exist");

            var addedEntry = await _dbContext.AddAsync(entity);

            return addedEntry.Entity;
        }
    }
}
