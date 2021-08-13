using System.Threading.Tasks;
using Armory.Shared.Domain.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;

namespace Armory.Shared.Infrastructure.Persistence
{
    public class UnitWork : IUnitWork
    {
        private readonly ArmoryDbContext _context;

        public UnitWork(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
