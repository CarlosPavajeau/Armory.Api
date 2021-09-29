using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Equipment> Find(string serial, bool noTracking)
        {
            var query = noTracking ? _context.Equipments.AsNoTracking() : _context.Equipments.AsTracking();

            return await query.FirstOrDefaultAsync(e => e.Serial == serial);
        }

        public async Task<Equipment> Find(string serial)
        {
            return await Find(serial, true);
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

        public async Task<IEnumerable<Equipment>> SearchAllByFlight(string flightCode)
        {
            return await _context.Equipments.AsNoTracking()
                .Where(e => e.FlightCode == flightCode)
                .ToListAsync();
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
