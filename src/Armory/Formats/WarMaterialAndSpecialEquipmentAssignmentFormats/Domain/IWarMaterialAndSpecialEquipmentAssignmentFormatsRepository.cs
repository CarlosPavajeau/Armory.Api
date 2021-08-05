using System.Threading.Tasks;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public interface IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository
    {
        Task Save(WarMaterialAndSpecialEquipmentAssignmentFormat format);
    }
}
