using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Explosives.Infrastructure.Persistence
{
    public class MySqlExplosivesRepository : Repository<Explosive, string>, IExplosivesRepository
    {
        public MySqlExplosivesRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Explosive> Find(string serial, bool noTracking)
        {
            var query = noTracking ? Context.Explosives.AsNoTracking() : Context.Explosives.AsTracking();

            return await query.FirstOrDefaultAsync(e => e.Serial == serial);
        }

        public async Task<IEnumerable<Explosive>> SearchAllByFlight(string flightCode)
        {
            return await Context.Explosives.AsNoTracking()
                .Where(e => e.FlightCode == flightCode)
                .ToListAsync();
        }

        public async Task Update(Explosive newExplosive)
        {
            Context.Update(newExplosive);
            await Context.SaveChangesAsync();
        }
    }
}
