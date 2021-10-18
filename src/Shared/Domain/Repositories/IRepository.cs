using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.Shared.Domain.Repositories
{
    public interface IRepository<T, in TKey> where T : class
    {
        Task Save(T entity);

        Task<T> Find(TKey key, bool noTracking);
        Task<T> Find(TKey key);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> SearchAll();
    }
}
