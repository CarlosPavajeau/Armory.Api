using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Armory.Squads.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squads.Infrastructure.Persistence
{
    public class MySqlSquadsRepository : Repository<Squad, string>, ISquadsRepository
    {
        public MySqlSquadsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Squad> Find(string code, bool noTracking)
        {
            var query = noTracking ? Context.Squads.AsNoTracking() : Context.Squads.AsTracking();

            return await query
                .Include(s => s.Owner)
                .ThenInclude(o => o.Degree)
                .FirstOrDefaultAsync(s => s.Code == code);
        }

        public override async Task<IEnumerable<Squad>> SearchAll()
        {
            return await Context.Squads
                .AsNoTracking()
                .Include(s => s.Owner)
                .ThenInclude(o => o.Degree)
                .ToListAsync();
        }
    }
}
