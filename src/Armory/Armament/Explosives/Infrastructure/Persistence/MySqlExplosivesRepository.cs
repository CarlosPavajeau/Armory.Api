using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Explosives.Infrastructure.Persistence
{
    public class MySqlExplosivesRepository : IExplosivesRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlExplosivesRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Explosive explosive)
        {
            await _context.Explosives.AddAsync(explosive);
            await _context.SaveChangesAsync();
        }

        public async Task<Explosive> Find(string code, bool noTracking = true)
        {
            if (noTracking)
                return await _context.Explosives
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Code == code);

            return await _context.Explosives.FindAsync(code);
        }

        public async Task<IEnumerable<Explosive>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
                return await _context.Explosives
                    .AsNoTracking()
                    .ToListAsync();

            return await _context.Explosives.ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<Explosive, bool>> predicate)
        {
            return await _context.Explosives.AnyAsync(predicate);
        }

        public async Task Update(Explosive newExplosive)
        {
            _context.Update(newExplosive);
            await _context.SaveChangesAsync();
        }
    }
}
