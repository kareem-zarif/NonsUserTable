using NonsUserTable.IRepos;

namespace NonsUserTable.IUnitOfWork
{
    public interface IUOW : IDisposable
    {
        IUserRepo userRepo { get; }
        IRoleRepo roleRepo { get; }
        IUserRoleRepo userRoleRepo { get; }
        IPageRepo pageRepo { get; }
        IRolePageRepo rolePageRepo { get; }
        Task<int> CompleteAsync();

        // in  interface
        // property=> fordata access
        // methods =>for actions and operations
    }
}
