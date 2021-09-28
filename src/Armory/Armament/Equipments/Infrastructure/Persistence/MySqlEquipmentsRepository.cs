using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Equipments.Infrastructure.Persistence
{
    public class MySqlEquipmentsRepository : IEquipmentsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlEquipmentsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task<Equipment> Find(string series, bool noTracking)
        {
            var query = noTracking ? _context.Equipments.AsNoTracking() : _context.Equipments.AsTracking();

            return await query.FirstOrDefaultAsync(e => e.Series == series);
        }

        public async Task<Equipment> Find(string series)
        {
            return await Find(series, true);
        }

        public async Task<IEnumerable<Equipment>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Equipments.AsNoTracking() : _context.Equipments.AsTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> SearchAll()
        {
            return await SearchAll(true);
        }

        public async Task<bool> Any(Expression<Func<Equipment, bool>> predicate)
        {
            return await _context.Equipments.AnyAsync(predicate);
        }

        public async Task Update(Equipment newEquipment)
        {
            _context.Equipments.Update(newEquipment);
            await _context.SaveChangesAsync();
        }
    }
}
