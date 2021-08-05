using System.Threading.Tasks;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;

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
    }
}
