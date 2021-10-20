using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Armory.Troopers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Troopers.Infrastructure.Persistence
{
    public class MySqlTroopersRepository : Repository<Troop, string>, ITroopersRepository
    {
        public MySqlTroopersRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<Troop> Find(string id, bool noTracking)
        {
            var query = noTracking ? Context.Troopers.AsNoTracking() : Context.Troopers.AsTracking();

            return await query
                .Include(t => t.Fireteam)
                .Include(t => t.Degree)
                .ThenInclude(d => d.Rank)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public override async Task<IEnumerable<Troop>> SearchAll()
        {
            return await Context.Troopers
                .AsNoTracking()
                .Include(t => t.Fireteam)
                .Include(t => t.Degree)
                .ThenInclude(d => d.Rank)
                .OrderBy(t => t.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Troop>> SearchAllByFireTeam(string fireTeamCode)
        {
            return await Context.Troopers
                .AsNoTracking()
                .Include(t => t.Degree)
                .Where(t => t.FireteamCode == fireTeamCode)
                .ToListAsync();
        }

        public async Task Update(Troop newTroop)
        {
            Context.Troopers.Update(newTroop);
            await Context.SaveChangesAsync();
        }
    }
}
