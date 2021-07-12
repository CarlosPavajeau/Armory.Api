using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Armament.Explosives.Infrastructure.Persistence
{
    public class MySqlExplosivesRepository : IExplosivesRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlExplosivesRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(Explosive explosive)
        {
            await _context.Explosives.AddAsync(explosive);
            await _context.SaveChangesAsync();
        }

        public async Task<Explosive> Find(string code)
        {
            return await _context.Explosives.FindAsync(code);
        }

        public async Task<IEnumerable<Explosive>> SearchAll()
        {
            return await _context.Explosives.ToListAsync();
        }

        public async Task Update(Explosive newExplosive)
        {
            _context.Update(newExplosive);
            await _context.SaveChangesAsync();
        }
    }
}