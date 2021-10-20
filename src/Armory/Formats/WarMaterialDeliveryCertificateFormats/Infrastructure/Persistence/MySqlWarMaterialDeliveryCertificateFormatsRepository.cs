using System.Linq;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Infrastructure.Persistence
{
    public class MySqlWarMaterialDeliveryCertificateFormatsRepository :
        Repository<WarMaterialDeliveryCertificateFormat, int>, IWarMaterialDeliveryCertificateFormatsRepository
    {
        public MySqlWarMaterialDeliveryCertificateFormatsRepository(ArmoryDbContext context) : base(context)
        {
        }

        public override async Task<WarMaterialDeliveryCertificateFormat> Find(int id, bool noTracking)
        {
            var query = noTracking
                ? Context.WarMaterialDeliveryCertificateFormats.AsNoTracking()
                : Context.WarMaterialDeliveryCertificateFormats.AsTracking();

            var format = await query
                .AsSplitQuery()
                .Include(f => f.WarMaterialDeliveryCertificateFormatAmmunition)
                .ThenInclude(x => x.Ammunition)
                .Include(f => f.WarMaterialDeliveryCertificateFormatEquipments)
                .ThenInclude(x => x.Equipment)
                .Include(f => f.WarMaterialDeliveryCertificateFormatExplosives)
                .ThenInclude(x => x.Explosive)
                .Include(x => x.WarMaterialDeliveryCertificateFormatWeapons)
                .ThenInclude(x => x.Weapon)
                .Include(f => f.Squad)
                .ThenInclude(s => s.Owner)
                .Include(f => f.Flight)
                .ThenInclude(x => x.Owner)
                .Include(f => f.Fireteam)
                .ThenInclude(x => x.Owner)
                .Include(f => f.Receiver)
                .ThenInclude(r => r.Degree)
                .ThenInclude(d => d.Rank)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (format == null)
            {
                return null;
            }

            if (format.WarMaterialDeliveryCertificateFormatAmmunition != null)
            {
                format.Ammunition = format.WarMaterialDeliveryCertificateFormatAmmunition
                    .Select(x => x.Ammunition)
                    .ToHashSet();
            }

            if (format.WarMaterialDeliveryCertificateFormatEquipments != null)
            {
                format.Equipments = format.WarMaterialDeliveryCertificateFormatEquipments
                    .Select(x => x.Equipment)
                    .ToHashSet();
            }

            if (format.WarMaterialDeliveryCertificateFormatExplosives != null)
            {
                format.Explosives = format.WarMaterialDeliveryCertificateFormatExplosives
                    .Select(x => x.Explosive)
                    .ToHashSet();
            }

            if (format.WarMaterialDeliveryCertificateFormatWeapons != null)
            {
                format.Weapons = format.WarMaterialDeliveryCertificateFormatWeapons
                    .Select(x => x.Weapon)
                    .ToHashSet();
            }

            return format;
        }
    }
}
