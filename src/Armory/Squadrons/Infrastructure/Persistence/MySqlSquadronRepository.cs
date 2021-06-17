using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Squadrons.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squadrons.Infrastructure.Persistence
{
    public class MySqlSquadronRepository : ISquadronRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlSquadronRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Squadron squadron)
        {
            await _context.Squadrons.AddAsync(squadron);
            await _context.SaveChangesAsync();
        }

        public async Task<Squadron> Find(string code)
        {
            return await _context.Squadrons.FindAsync(code);
        }

        public async Task<IEnumerable<Squadron>> GetAll()
        {
            return await _context.Squadrons.ToListAsync();
        }
    }
}
