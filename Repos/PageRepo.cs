using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.Entites;
using NonsUserTable.IRepos;

namespace NonsUserTable.Repos
{
    public class PageRepo : BaseRepo<Page, Guid>, IPageRepo
    {
        private readonly UserTableDBContext _context;
        private readonly DbSet<Page> _pages;
        public PageRepo(UserTableDBContext context) : base(context)
        {
            _context = context;
            _pages = _context.Set<Page>();
        }
        public override async Task<Page> CreateAsync(Page entity)
        {
            var foundPage = await checkExistPageReturnPageAsync(entity.Name.ToUpper(), entity.PageNumber);

            if (foundPage != null)
                throw new Exception($"Already Exist Page with : {entity.Name} and {entity.PageNumber}");

            //attach 
            var createdPage = await _pages.AddAsync(entity);

            return createdPage.Entity;
        }

        private async Task<Page> checkExistPageReturnPageAsync(string name, int pageNum)
        {
            var foundPage = await _pages.AsNoTracking().FirstOrDefaultAsync(
                x => x.Name.Equals(name.ToUpper()) && x.PageNumber.Equals(pageNum)
            );

            return foundPage;
        }
    }
}
