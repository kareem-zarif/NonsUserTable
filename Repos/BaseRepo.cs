using Microsoft.EntityFrameworkCore;
using NonsUserTable.DBContext;
using NonsUserTable.Entites;
using NonsUserTable.IRepos;
using System.Linq.Expressions;

namespace NonsUserTable.Repos
{
    public class BaseRepo<TEntity, TId> : IBaseRepo<TEntity, TId>
        where TEntity : BaseEntity<TId>
        where TId : struct
    {
        private readonly UserTableDBContext _context;//db
        private readonly DbSet<TEntity> _dbset;//represent table in db
        public BaseRepo(UserTableDBContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>(); //_dbset not sent in constructor
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            //chceck found item with the entityRepo CreateAsync(override this)
            //attach
            var entityEntry = await _dbset.AddAsync(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TId id)
        {
            var foundItem = await checkEntityExisrAsyn(id);
            _dbset.Remove(foundItem);

            return foundItem;
        }

        private async Task<TEntity> checkEntityExisrAsyn(TId id)
        {
            var foundItem = await _dbset.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)); //asNoTracking() => make detaching
            if (foundItem == null)
                throw new Exception($"Not Found {nameof(TEntity)} with id : {id}");

            return foundItem;
        }

        public virtual async Task<TEntity> GetAsync(TId id)
        {
            return await checkEntityExisrAsyn(id);
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {

            if (predicate is not null)
                return _dbset.AsNoTracking().Where(predicate).ToListAsync();

            return _dbset.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //ensure detach
            var fouundItem = await checkEntityExisrAsyn(entity.Id);

            //attach
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
