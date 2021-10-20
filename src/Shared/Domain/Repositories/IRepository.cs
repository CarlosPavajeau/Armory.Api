using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Shared.Domain.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        Task Save(TEntity entity);

        Task<TEntity> Find(TKey key, bool noTracking);
        Task<TEntity> Find(TKey key);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> SearchAll();

        Task Delete(TEntity entity);
    }
}
