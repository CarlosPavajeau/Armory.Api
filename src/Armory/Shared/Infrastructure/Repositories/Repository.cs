using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Shared.Domain.Repositories;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ArmoryDbContext Context;

        protected Repository(ArmoryDbContext context)
        {
            Context = context;
        }

        public async Task Save(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public abstract Task<TEntity> Find(TKey key, bool noTracking);
        public abstract Task<TEntity> Find(TKey key);

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> SearchAll()
        {
            return await Context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
