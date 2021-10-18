using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Infrastructure.Repositories
{
    public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly ArmoryDbContext Context;

        protected Repository(ArmoryDbContext context)
        {
            Context = context;
        }

        public async Task Save(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public abstract Task<T> Find(TKey key, bool noTracking);
        public abstract Task<T> Find(TKey key);

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AnyAsync(predicate);
        }

        public virtual async Task<IEnumerable<T>> SearchAll()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
