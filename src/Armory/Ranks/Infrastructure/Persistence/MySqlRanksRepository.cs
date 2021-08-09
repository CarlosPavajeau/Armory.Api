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

        public async Task<Rank> Find(int id, bool noTracking = true)
        {
            if (noTracking)
                return await _context.Ranks
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id);

            return await _context.Ranks.FindAsync(id);
        }

        public async Task<IEnumerable<Rank>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
                return await _context.Ranks
                    .AsNoTracking()
                    .ToListAsync();

            return await _context.Ranks.ToListAsync();
        }
    }
}
