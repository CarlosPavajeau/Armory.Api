using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Weapons.Infrastructure.Persistence
{
    public class MySqlWeaponsRepository : IWeaponsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlWeaponsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Weapon weapon)
        {
            await _context.Weapons.AddAsync(weapon);
            await _context.SaveChangesAsync();
        }

        public async Task<Weapon> Find(string serial, bool noTracking)
        {
            var query = noTracking ? _context.Weapons.AsNoTracking() : _context.Weapons.AsTracking();

            return await query
                .Include(w => w.Holder)
                .FirstOrDefaultAsync(w => w.Serial == serial);
        }

        public async Task<Weapon> Find(string serial)
        {
            return await Find(serial, true).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Weapon>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Weapons.AsNoTracking() : _context.Weapons.AsTracking();

            return await query
                .Include(w => w.Holder)
                .ThenInclude(h => h.Degree)
                .ToListAsync();
        }

        public async Task<IEnumerable<Weapon>> SearchAll()
        {
            return await SearchAll(true).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Weapon>> SearchAllByFlight(string flightCode)
        {
            return await _context.Weapons.AsNoTracking()
                .Where(w => w.FlightCode == flightCode)
                .ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<Weapon, bool>> predicate)
        {
            return await _context.Weapons.AnyAsync(predicate);
        }

        public async Task Update(Weapon newWeapon)
        {
            _context.Update(newWeapon);
            await _context.SaveChangesAsync();
        }
    }
}
