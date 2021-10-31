using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Infrastructure.Persistence
{
    public class MySqlAssignedWeaponMagazineFormatsRepository : Repository<AssignedWeaponMagazineFormat, int>,
        IAssignedWeaponMagazineFormatsRepository
    {
        public MySqlAssignedWeaponMagazineFormatsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<AssignedWeaponMagazineFormat> Find(int id, bool noTracking)
        {
            var query = noTracking
                ? Context.AssignedWeaponMagazineFormats.AsNoTracking()
                : Context.AssignedWeaponMagazineFormats.AsTracking();

            return await query
                .Include(f => f.Records)
                .ThenInclude(x => x.Troop)
                .ThenInclude(x => x.Degree)
                .Include(f => f.Records)
                .ThenInclude(x => x.Weapon)
                .Include(f => f.Squad)
                .ThenInclude(s => s.Owner)
                .Include(f => f.Flight)
                .ThenInclude(f => f.Commander)
                .Include(f => f.Fireteam)
                .ThenInclude(f => f.Owner)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
