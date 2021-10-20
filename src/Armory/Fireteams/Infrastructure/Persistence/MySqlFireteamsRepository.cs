using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Fireteams.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Fireteams.Infrastructure.Persistence
{
    public class MySqlFireteamsRepository : Repository<Fireteam, string>, IFireteamsRepository
    {
        public MySqlFireteamsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Fireteam> Find(string code, bool noTracking)
        {
            var query = noTracking ? Context.Fireteams.AsNoTracking() : Context.Fireteams.AsTracking();

            return await query
                .Include(s => s.Owner)
                .ThenInclude(o => o.Degree)
                .ThenInclude(d => d.Rank)
                .Include(s => s.Flight)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public override async Task<IEnumerable<Fireteam>> SearchAll()
        {
            return await Context.Fireteams
                .AsNoTracking()
                .Include(s => s.Owner)
                .ThenInclude(o => o.Degree)
                .Include(s => s.Flight)
                .ToListAsync();
        }

        public async Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode)
        {
            return await Context.Fireteams
                .AsNoTracking()
                .Where(s => s.FlightCode == flightCode)
                .ToListAsync();
        }
    }
}
