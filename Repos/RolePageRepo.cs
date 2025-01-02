using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.Entites;
using NonsUserTable.IRepos;

namespace NonsUserTable.Repos
{
    public class RolePageRepo : BaseRepo<RolePage, Guid>, IRolePageRepo
    {
        private readonly UserTableDBContext _context;
        private readonly DbSet<RolePage> _rolePages;
        public RolePageRepo(UserTableDBContext context) : base(context)
        {
            _context = context;
            _rolePages = _context.Set<RolePage>();
        }
        public override async Task<RolePage> CreateAsync(RolePage entity)
        {
            var existRole = await _context.Roles.FindAsync(entity.RoleId);
            var existPage = await _context.Pages.FindAsync(entity.PageId);
            if (existRole == null || existPage == null)
                throw new Exception($"Role OR Page is not exists");

            var existsRolePage = await _context.RolePages.AsNoTracking().FirstOrDefaultAsync(
                x => x.RoleId.Equals(entity.RoleId) && x.PageId.Equals(entity.PageId)
                );

            if (existsRolePage != null)
                throw new Exception($"already exists Role_Page : {entity.Id}");

            var createdItem = await _rolePages.AddAsync(entity);

            return createdItem.Entity;
        }
    }
}
