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

        public async Task<Weapon> Find(string code, bool noTracking = true)
        {
            if (noTracking)
                return await _context.Weapons
                    .AsNoTracking()
                    .FirstOrDefaultAsync(w => w.Code == code);

            return await _context.Weapons.FindAsync(code);
        }

        public async Task<IEnumerable<Weapon>> SearchAll(bool noTracking = true)
        {
            return await _context.Weapons.ToListAsync();
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
