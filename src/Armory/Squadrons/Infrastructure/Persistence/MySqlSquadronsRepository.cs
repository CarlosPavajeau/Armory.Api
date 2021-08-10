using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Squadrons.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squadrons.Infrastructure.Persistence
{
    public class MySqlSquadronsRepository : ISquadronsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlSquadronsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Squadron squadron)
        {
            await _context.Squadrons.AddAsync(squadron);
            await _context.SaveChangesAsync();
        }

        public async Task<Squadron> Find(string code, bool noTracking = true)
        {
            if (noTracking)
            {
                return await _context.Squadrons
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Code == code);
            }

            return await _context.Squadrons.FindAsync(code);
        }

        public async Task<bool> Any(Expression<Func<Squadron, bool>> predicate)
        {
            return await _context.Squadrons.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Squadron>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
            {
                return await _context.Squadrons
                    .AsNoTracking()
                    .ToListAsync();
            }

            return await _context.Squadrons.ToListAsync();
        }
    }
}
