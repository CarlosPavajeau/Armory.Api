using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Explosive> Find(string serial, bool noTracking)
        {
            var query = noTracking ? _context.Explosives.AsNoTracking() : _context.Explosives.AsTracking();

            return await query.FirstOrDefaultAsync(e => e.Serial == serial);
        }

        public async Task<Explosive> Find(string serial)
        {
            return await Find(serial, true);
        }

        public async Task<IEnumerable<Explosive>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Explosives.AsNoTracking() : _context.Explosives.AsTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Explosive>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<IEnumerable<Explosive>> SearchAllByFlight(string flightCode)
        {
            return await _context.Explosives.AsNoTracking()
                .Where(e => e.FlightCode == flightCode)
                .ToListAsync();
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
