using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Weapons.Infrastructure.Persistence
{
    public class MySqlWeaponsRepository : Repository<Weapon, string>, IWeaponsRepository
    {
        public MySqlWeaponsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Weapon> Find(string serial, bool noTracking)
        {
            var query = noTracking ? Context.Weapons.AsNoTracking() : Context.Weapons.AsTracking();

            return await query
                .Include(w => w.Holder)
                .ThenInclude(h => h.Degree)
                .FirstOrDefaultAsync(w => w.Serial == serial);
        }

        public override async Task<IEnumerable<Weapon>> SearchAll()
        {
            return await Context.Weapons
                .AsNoTracking()
                .Include(w => w.Holder)
                .ThenInclude(h => h.Degree)
                .ToListAsync();
        }

        public async Task<IEnumerable<Weapon>> SearchAllByFlight(string flightCode)
        {
            return await Context.Weapons.AsNoTracking()
                .Where(w => w.FlightCode == flightCode)
                .ToListAsync();
        }

        public async Task Update(Weapon newWeapon)
        {
            Context.Update(newWeapon);
            await Context.SaveChangesAsync();
        }
    }
}
