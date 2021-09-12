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

        public async Task<Squadron> Find(string code, bool noTracking)
        {
            var query = noTracking ? _context.Squadrons.AsNoTracking() : _context.Squadrons.AsTracking();

            return await query
                .Include(s => s.Owner)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public async Task<Squadron> Find(string code)
        {
            return await Find(code, true);
        }

        public async Task<bool> Any(Expression<Func<Squadron, bool>> predicate)
        {
            return await _context.Squadrons.AnyAsync(predicate);
        }

        public async Task<IEnumerable<Squadron>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Squadrons.AsNoTracking() : _context.Squadrons.AsTracking();

            return await query
                .Include(s => s.Owner)
                .ToListAsync();
        }

        public async Task<IEnumerable<Squadron>> SearchAll()
        {
            return await SearchAll(true);
        }
    }
}
