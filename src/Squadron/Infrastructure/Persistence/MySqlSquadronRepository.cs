using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Squadron.Domain;
using Armory.Squadron.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Squadron.Infrastructure.Persistence
{
    public class MySqlSquadronRepository : ISquadronRepository
    {
        private readonly SquadronDbContext _context;

        public MySqlSquadronRepository(SquadronDbContext context)
        {
            _context = context;
        }

        public async Task Save(Domain.Squadron squadron)
        {
            await _context.Squadrons.AddAsync(squadron);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Squadron> Find(string code)
        {
            return await _context.Squadrons.FindAsync(code);
        }

        public async Task<IEnumerable<Domain.Squadron>> GetAll()
        {
            return await _context.Squadrons.ToListAsync();
        }
    }
}
