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
            if (noTracking)
                return await _context.Degrees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Id == id);

            return await _context.Degrees.FindAsync(id);
        }

        public async Task<IEnumerable<Degree>> SearchAll(bool noTracking = true)
        {
            if (noTracking)
                return await _context.Degrees
                    .AsNoTracking()
                    .ToListAsync();

            return await _context.Degrees.ToListAsync();
        }

        public async Task<IEnumerable<Degree>> SearchAllByRank(int rankId, bool noTracking = true)
        {
            if (noTracking)
                return await _context.Degrees
                    .AsNoTracking()
                    .Where(d => d.RankId == rankId)
                    .ToListAsync();

            return await _context.Degrees.Where(d => d.RankId == rankId).ToListAsync();
        }
    }
}
