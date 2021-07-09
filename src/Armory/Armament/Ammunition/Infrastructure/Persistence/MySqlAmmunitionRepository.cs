using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Ammunition.Infrastructure.Persistence
{
    public class MySqlAmmunitionRepository : IAmmunitionRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlAmmunitionRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Domain.Ammunition ammunition)
        {
            await _context.Ammunition.AddAsync(ammunition);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Ammunition> Find(string code)
        {
            return await _context.Ammunition.FindAsync(code);
        }

        public async Task<IEnumerable<Domain.Ammunition>> SearchAll()
        {
            return await _context.Ammunition.ToListAsync();
        }

        public async Task Update(Domain.Ammunition newAmmunition)
        {
            _context.Ammunition.Update(newAmmunition);
            await _context.SaveChangesAsync();
        }
    }
}
