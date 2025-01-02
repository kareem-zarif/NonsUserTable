using NonsUserTable.DBContext;
using NonsUserTable.IRepos;
using NonsUserTable.IUnitOfWork;

namespace NonsUserTable.UnitOfWork
{
    public class UOW : IUOW
    {
        private readonly UserTableDBContext _context;
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IUserRoleRepo _userRoleRepo;
        private readonly IPageRepo _pageRepo;
        private readonly IRolePageRepo _rolePageRepo;
        public UOW(IUserRepo userRepo, UserTableDBContext context, IRoleRepo roleRepo, IUserRoleRepo userRoleRepo, IPageRepo pageRole, IRolePageRepo rolePageRepo)
        {
            _context = context;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _userRoleRepo = userRoleRepo;
            _pageRepo = pageRole;
            _rolePageRepo = rolePageRepo;
        }

        public IUserRepo userRepo => _userRepo;
        public IRoleRepo roleRepo => _roleRepo;
        public IPageRepo pageRepo => _pageRepo;
        public IUserRoleRepo userRoleRepo => _userRoleRepo;
        public IRolePageRepo rolePageRepo => _rolePageRepo;

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
