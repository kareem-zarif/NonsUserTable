using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.Entites;
using NonsUserTable.IRepos;

namespace NonsUserTable.Repos
{
    public class UserRepo : BaseRepo<User, Guid>, IUserRepo
    {
        private readonly UserTableDBContext _context;
        private readonly DbSet<User> _users;
        public UserRepo(UserTableDBContext context) : base(context)
        {
            _context = context;
            _users = context.Set<User>();
        }
        public override async Task<User> CreateAsync(User entity)
        {
            var foundUser = await checkEntityExistsByEmailAsync(entity.UserEmail);
            if (foundUser != null)
            {
                throw new Exception($"Already Exists : {foundUser.UserName} with email : {foundUser.UserEmail} | id : {foundUser.Id}");
            }
            //attach
            var entityEntry = await _users.AddAsync(entity);
            return entityEntry.Entity;
        }
        public async Task<User> GetAsyncByEmail(string email)
        {
            var foundUser = await checkEntityExistsByEmailAsync(email);
            if (foundUser is null)
                throw new Exception($"Not Found User : {email}");

            return foundUser;
        }

        private async Task<User> checkEntityExistsByEmailAsync(string email)
        {
            var foundUser = await _users.AsNoTracking().FirstOrDefaultAsync(x => x.UserEmail.Equals(email));
            if (foundUser is null)
            {
                return null;
            }

            return foundUser;
        }
    }
}
