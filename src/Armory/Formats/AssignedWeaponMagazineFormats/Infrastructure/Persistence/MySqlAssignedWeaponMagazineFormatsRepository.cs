using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Infrastructure.Persistence
{
    public class MySqlAssignedWeaponMagazineFormatsRepository : IAssignedWeaponMagazineFormatsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlAssignedWeaponMagazineFormatsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(AssignedWeaponMagazineFormat format)
        {
            await _context.AssignedWeaponMagazineFormats.AddAsync(format);
            await _context.SaveChangesAsync();
        }

        public async Task<AssignedWeaponMagazineFormat> Find(int id, bool noTracking)
        {
            var query = noTracking
                ? _context.AssignedWeaponMagazineFormats.AsNoTracking()
                : _context.AssignedWeaponMagazineFormats.AsTracking();

            return await query
                .Include(f => f.Records)
                .ThenInclude(x => x.Troop)
                .ThenInclude(x => x.Degree)
                .Include(f => f.Records)
                .ThenInclude(x => x.Weapon)
                .Include(f => f.Squad)
                .ThenInclude(s => s.Owner)
                .Include(f => f.Flight)
                .ThenInclude(f => f.Owner)
                .Include(f => f.Fireteam)
                .ThenInclude(f => f.Owner)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<AssignedWeaponMagazineFormat> Find(int id)
        {
            return await Find(id, true);
        }
    }
}
