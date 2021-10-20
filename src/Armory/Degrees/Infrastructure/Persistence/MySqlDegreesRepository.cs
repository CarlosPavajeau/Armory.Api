using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Degrees.Infrastructure.Persistence
{
    public class MySqlDegreesRepository : Repository<Degree, int>, IDegreesRepository
    {
        public MySqlDegreesRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Degree> Find(int id, bool noTracking)
        {
            var query = noTracking ? Context.Degrees.AsNoTracking() : Context.Degrees.AsTracking();

            return await query
                .Include(d => d.Rank)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public override async Task<IEnumerable<Degree>> SearchAll()
        {
            return await Context.Degrees
                .AsNoTracking()
                .Include(d => d.Rank)
                .ToListAsync();
        }

        public async Task<IEnumerable<Degree>> SearchAllByRank(int rankId)
        {
            return await Context.Degrees
                .AsNoTracking()
                .Where(d => d.RankId == rankId)
                .ToListAsync();
        }
    }
}
