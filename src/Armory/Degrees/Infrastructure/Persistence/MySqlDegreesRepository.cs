using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Degrees.Infrastructure.Persistence
{
    public class MySqlDegreesRepository : IDegreesRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlDegreesRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Degree degree)
        {
            await _context.Degrees.AddAsync(degree);
            await _context.SaveChangesAsync();
        }

        public async Task<Degree> Find(int id, bool noTracking = true)
        {
            var query = noTracking ? _context.Degrees.AsNoTracking() : _context.Degrees.AsTracking();

            return await query
                .Include(d => d.Rank)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Degree>> SearchAll(bool noTracking = true)
        {
            var query = noTracking ? _context.Degrees.AsNoTracking() : _context.Degrees.AsTracking();

            return await query
                .Include(d => d.Rank)
                .ToListAsync();
        }

        public async Task<IEnumerable<Degree>> SearchAllByRank(int rankId, bool noTracking = true)
        {
            var query = noTracking ? _context.Degrees.AsNoTracking() : _context.Degrees.AsTracking();

            return await query
                .Where(d => d.RankId == rankId)
                .ToListAsync();
        }
    }
}
