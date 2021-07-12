using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Troopers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Armory.Troopers.Infrastructure.Persistence
{
    public class MySqlTroopersRepository : ITroopersRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlTroopersRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Troop troop)
        {
            await _context.Troopers.AddAsync(troop);
            await _context.SaveChangesAsync();
        }

        public async Task<Troop> Find(string id)
        {
            return await _context.Troopers.FindAsync(id);
        }

        public async Task<IEnumerable<Troop>> SearchAll()
        {
            return await _context.Troopers.ToListAsync();
        }

        public async Task Update(Troop newTroop)
        {
            _context.Troopers.Update(newTroop);
            await _context.SaveChangesAsync();
        }
    }
}
