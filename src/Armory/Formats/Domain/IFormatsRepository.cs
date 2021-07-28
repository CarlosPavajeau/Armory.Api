using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Formats.Domain
{
    public interface IFormatsRepository
    {
        Task Save(WarMaterialAndSpecialEquipmentAssignmentFormat format);
        Task Save(WarMaterialDeliveryCertificateFormat format);
        Task<WarMaterialAndSpecialEquipmentAssignmentFormat> FindWarMaterialAndSpecialEquipmentAssignmentFormat(int id);
        Task<WarMaterialDeliveryCertificateFormat> FindWarMaterialDeliveryCertificateFormat(int id);
    }
}
