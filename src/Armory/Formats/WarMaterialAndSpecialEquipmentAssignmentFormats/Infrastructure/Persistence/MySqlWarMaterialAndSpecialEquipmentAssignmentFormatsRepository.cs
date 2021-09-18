using System.Linq;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Infrastructure.Persistence
{
    public class
        MySqlWarMaterialAndSpecialEquipmentAssignmentFormatsRepository :
            IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlWarMaterialAndSpecialEquipmentAssignmentFormatsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            await _context.WarMaterialAndSpecialEquipmentAssignmentFormats.AddAsync(format);
            await _context.SaveChangesAsync();
        }

        public async Task<WarMaterialAndSpecialEquipmentAssignmentFormat> Find(int id, bool noTracking)
        {
            var query = noTracking
                ? _context.WarMaterialAndSpecialEquipmentAssignmentFormats.AsNoTracking()
                : _context.WarMaterialAndSpecialEquipmentAssignmentFormats.AsTracking();
            var format = await query
                .AsSplitQuery()
                .Include(f => f.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition)
                .ThenInclude(x => x.Ammunition)
                .Include(f => f.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments)
                .ThenInclude(x => x.Equipment)
                .Include(f => f.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives)
                .ThenInclude(x => x.Explosive)
                .Include(f => f.WarMaterialAndSpecialEquipmentAssignmentFormatWeapons)
                .ThenInclude(x => x.Weapon)
                .Include(f => f.Flight)
                .ThenInclude(x => x.Owner)
                .Include(f => f.Squad)
                .ThenInclude(x => x.Owner)
                .Include(f => f.Receiver)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (format == null)
            {
                return null;
            }

            if (format.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition != null)
            {
                format.Ammunition =
                    format.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.Select(x => x.Ammunition)
                        .ToHashSet();
            }

            if (format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments != null)
            {
                format.Equipments = format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments
                    .Select(x => x.Equipment).ToHashSet();
            }

            if (format.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives != null)
            {
                format.Explosives = format.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives
                    .Select(x => x.Explosive).ToHashSet();
            }

            if (format.WarMaterialAndSpecialEquipmentAssignmentFormatWeapons != null)
            {
                format.Weapons = format.WarMaterialAndSpecialEquipmentAssignmentFormatWeapons.Select(x => x.Weapon)
                    .ToHashSet();
            }

            return format;
        }

        public async Task<WarMaterialAndSpecialEquipmentAssignmentFormat> Find(int id)
        {
            return await Find(id, true);
        }
    }
}
