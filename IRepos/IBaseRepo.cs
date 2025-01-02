using NonsUserTable.Entites;
using System.Linq.Expressions;

namespace NonsUserTable.IRepos
{
    public interface IBaseRepo<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TId : struct
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> GetAsync(TId id);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TId id);
    }
}
