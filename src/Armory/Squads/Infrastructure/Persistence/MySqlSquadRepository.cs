using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Squads.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squads.Infrastructure.Persistence
{
    public class MySqlSquadRepository : ISquadRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlSquadRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Squad squad)
        {
            await _context.Squads.AddAsync(squad);
            await _context.SaveChangesAsync();
        }

        public async Task<Squad> Find(string code)
        {
            return await _context.Squads.FindAsync(code);
        }

        public async Task<IEnumerable<Squad>> SearchAll()
        {
            return await _context.Squads.ToListAsync();
        }
    }
}
