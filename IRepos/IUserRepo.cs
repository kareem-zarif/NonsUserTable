using NonsUserTable.Entites;

namespace NonsUserTable.IRepos
{
    public interface IUserRepo : IBaseRepo<User, Guid>
    {
        Task<User> GetAsyncByEmail(string email);
    }
}
