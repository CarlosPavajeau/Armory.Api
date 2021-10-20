using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Equipments.Infrastructure.Persistence
{
    public class MySqlEquipmentsRepository : Repository<Equipment, string>, IEquipmentsRepository
    {
        public MySqlEquipmentsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Equipment> Find(string serial, bool noTracking)
        {
            var query = noTracking ? Context.Equipments.AsNoTracking() : Context.Equipments.AsTracking();

            return await query.FirstOrDefaultAsync(e => e.Serial == serial);
        }

        public async Task<IEnumerable<Equipment>> SearchAllByFlight(string flightCode)
        {
            return await Context.Equipments.AsNoTracking()
                .Where(e => e.FlightCode == flightCode)
                .ToListAsync();
        }

        public async Task Update(Equipment newEquipment)
        {
            Context.Equipments.Update(newEquipment);
            await Context.SaveChangesAsync();
        }
    }
}
