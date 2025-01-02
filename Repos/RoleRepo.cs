using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.Entites;
using NonsUserTable.IRepos;

namespace NonsUserTable.Repos
{
    public class RoleRepo : BaseRepo<Role, Guid>, IRoleRepo
    {
        private readonly UserTableDBContext _context;
        private readonly DbSet<Role> _roles;
        public RoleRepo(UserTableDBContext context) : base(context)
        {
            _context = context;
            _roles = _context.Set<Role>();
        }
        public override async Task<Role> CreateAsync(Role entity)
        {
            var foundRole = await checkEntityExisrAsyn(entity.Name);
            if (foundRole != null)
                throw new Exception($"Already Exists Role : {entity.Name}");

            //attach
            var entityEntry = await _context.AddAsync(entity);

            return entityEntry.Entity;
        }
        private async Task<Role> checkEntityExisrAsyn(string roleName)
        {
            //deattach
            var foundRole = await _roles.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(roleName));
            if (foundRole is null)
                return null;

            return foundRole;
        }
    }
}
