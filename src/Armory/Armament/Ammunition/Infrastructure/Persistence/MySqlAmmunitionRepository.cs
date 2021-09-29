using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Ammunition.Infrastructure.Persistence
{
    public class MySqlAmmunitionRepository : IAmmunitionRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlAmmunitionRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Domain.Ammunition ammunition)
        {
            await _context.Ammunition.AddAsync(ammunition);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Ammunition> Find(string lot, bool noTracking)
        {
            var query = noTracking ? _context.Ammunition.AsNoTracking() : _context.Ammunition.AsTracking();

            return await query.FirstOrDefaultAsync(c => c.Lot == lot);
        }

        public async Task<Domain.Ammunition> Find(string lot)
        {
            return await Find(lot, true);
        }

        public async Task<IEnumerable<Domain.Ammunition>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Ammunition.AsNoTracking() : _context.Ammunition.AsTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Domain.Ammunition>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<IEnumerable<Domain.Ammunition>> SearchAllByFlight(string flightCode)
        {
            return await _context.Ammunition.AsNoTracking()
                .Where(a => a.FlightCode == flightCode)
                .ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<Domain.Ammunition, bool>> predicate)
        {
            return await _context.Ammunition.AnyAsync(predicate);
        }

        public async Task Update(Domain.Ammunition newAmmunition)
        {
            _context.Ammunition.Update(newAmmunition);
            await _context.SaveChangesAsync();
        }
    }
}
