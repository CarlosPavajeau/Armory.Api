using System.Linq;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Infrastructure.Persistence
{
    public class MySqlWarMaterialDeliveryCertificateFormatsRepository : IWarMaterialDeliveryCertificateFormatsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlWarMaterialDeliveryCertificateFormatsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(WarMaterialDeliveryCertificateFormat format)
        {
            await _context.WarMaterialDeliveryCertificateFormats.AddAsync(format);
            await _context.SaveChangesAsync();
        }

        public async Task<WarMaterialDeliveryCertificateFormat> Find(int id, bool noTracking)
        {
            var query = noTracking
                ? _context.WarMaterialDeliveryCertificateFormats.AsNoTracking()
                : _context.WarMaterialDeliveryCertificateFormats.AsTracking();

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
                .Include(f => f.Unit)
                .Include(f => f.Dependency)
                .Include(f => f.Applicant)
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

        public async Task<WarMaterialDeliveryCertificateFormat> Find(int id)
        {
            return await Find(id, true);
        }
    }
}
