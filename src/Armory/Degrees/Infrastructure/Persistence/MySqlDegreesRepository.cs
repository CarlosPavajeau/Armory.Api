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

        public async Task<Degree> Find(int id)
        {
            return await _context.Degrees.FindAsync(id);
        }

        public async Task<IEnumerable<Degree>> SearchAll()
        {
            return await _context.Degrees.ToListAsync();
        }

        public async Task<IEnumerable<Degree>> SearchAllByRank(int rankId)
        {
            return await _context.Degrees.Where(d => d.RankId == rankId).ToListAsync();
        }
    }
}
