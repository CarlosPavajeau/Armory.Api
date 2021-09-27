using System;
using System.Collections.Generic;
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

        public async Task<Weapon> Find(string series, bool noTracking)
        {
            var query = noTracking ? _context.Weapons.AsNoTracking() : _context.Weapons.AsTracking();

            return await query
                .Include(w => w.Owner)
                .FirstOrDefaultAsync(w => w.Series == series);
        }

        public async Task<Weapon> Find(string series)
        {
            return await Find(series, true).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Weapon>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Weapons.AsNoTracking() : _context.Weapons.AsTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Weapon>> SearchAll()
        {
            return await SearchAll(true).ConfigureAwait(false);
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
