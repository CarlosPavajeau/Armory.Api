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

        public async Task<Equipment> Find(string code, bool noTracking = true)
        {
            if (noTracking)
            {
                return await _context.Equipments
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Code == code);
            }

            return await _context.Equipments.FindAsync(code);
        }

        public async Task<IEnumerable<Equipment>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
            {
                return await _context.Equipments
                    .AsNoTracking()
                    .ToListAsync();
            }

            return await _context.Equipments.ToListAsync();
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
