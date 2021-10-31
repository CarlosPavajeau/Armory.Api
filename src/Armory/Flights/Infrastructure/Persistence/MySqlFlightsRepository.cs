using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Flights.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Flights.Infrastructure.Persistence
{
    public class MySqlFlightsRepository : Repository<Flight, string>, IFlightsRepository
    {
        public MySqlFlightsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Flight> Find(string code, bool noTracking)
        {
            var query = noTracking ? Context.Flights.AsNoTracking() : Context.Flights.AsTracking();

            return await query
                .Include(s => s.Commander)
                .ThenInclude(o => o.Degree)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public override async Task<IEnumerable<Flight>> SearchAll()
        {
            return await Context.Flights
                .AsNoTracking()
                .Include(s => s.Commander)
                .ThenInclude(o => o.Degree)
                .ToListAsync();
        }
    }
}
