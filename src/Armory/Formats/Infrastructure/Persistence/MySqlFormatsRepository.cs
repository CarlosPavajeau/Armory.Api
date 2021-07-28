using System.Threading.Tasks;
using Armory.Formats.Domain;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;

namespace Armory.Formats.Infrastructure.Persistence
{
    public class MySqlFormatsRepository : IFormatsRepository
    {
        private readonly ArmoryDbContext _context;

        public MySqlFormatsRepository(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task Save(WarMaterialAndSpecialEquipmentAssignmentFormat format)
        {
            await _context.WarMaterialAndSpecialEquipmentAssignmentFormats.AddAsync(format);
            await _context.SaveChangesAsync();
        }

        public async Task Save(WarMaterialDeliveryCertificateFormat format)
        {
            await _context.WarMaterialDeliveryCertificateFormats.AddAsync(format);
            await _context.SaveChangesAsync();
        }

        public async Task<WarMaterialAndSpecialEquipmentAssignmentFormat>
            FindWarMaterialAndSpecialEquipmentAssignmentFormat(int id)
        {
            return await _context.WarMaterialAndSpecialEquipmentAssignmentFormats.FindAsync(id);
        }

        public async Task<WarMaterialDeliveryCertificateFormat> FindWarMaterialDeliveryCertificateFormat(int id)
        {
            return await _context.WarMaterialDeliveryCertificateFormats.FindAsync(id);
        }
    }
}
