using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Ammunition.Infrastructure.Persistence
{
    public class MySqlAmmunitionRepository : Repository<Domain.Ammunition, string>, IAmmunitionRepository
    {
        public MySqlAmmunitionRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Domain.Ammunition> Find(string lot, bool noTracking)
        {
            var query = noTracking ? Context.Ammunition.AsNoTracking() : Context.Ammunition.AsTracking();

            return await query.FirstOrDefaultAsync(c => c.Lot == lot);
        }

        public async Task<IEnumerable<Domain.Ammunition>> SearchAllByFlight(string flightCode)
        {
            return await Context.Ammunition.AsNoTracking()
                .Where(a => a.FlightCode == flightCode)
                .ToListAsync();
        }

        public async Task Update(Domain.Ammunition newAmmunition)
        {
            Context.Ammunition.Update(newAmmunition);
            await Context.SaveChangesAsync();
        }
    }
}
