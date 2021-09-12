using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Ranks.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Ranks.Infrastructure.Persistence
{
    public class MySqlRanksRepository : IRanksRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlRanksRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Rank rank)
        {
            await _context.Ranks.AddAsync(rank);
            await _context.SaveChangesAsync();
        }

        public async Task<Rank> Find(int id, bool noTracking)
        {
            var query = noTracking ? _context.Ranks.AsNoTracking() : _context.Ranks.AsTracking();

            return await query.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rank> Find(int id)
        {
            return await Find(id, true);
        }

        public async Task<IEnumerable<Rank>> SearchAll(bool noTracking)
        {
            var query = noTracking ? _context.Ranks.AsNoTracking() : _context.Ranks.AsTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Rank>> SearchAll()
        {
            return await SearchAll(true);
        }
    }
}
