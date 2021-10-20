using System.Threading.Tasks;
using Armory.Ranks.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Ranks.Infrastructure.Persistence
{
    public class MySqlRanksRepository : Repository<Rank, int>, IRanksRepository
    {
        public MySqlRanksRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Rank> Find(int id, bool noTracking)
        {
            var query = noTracking ? Context.Ranks.AsNoTracking() : Context.Ranks.AsTracking();

            return await query.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
