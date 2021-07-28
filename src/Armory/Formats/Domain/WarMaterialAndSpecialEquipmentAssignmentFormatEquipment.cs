using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatEquipment
    {
        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string EquipmentCode { get; set; }
        [ForeignKey("EquipmentCode")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public WarMaterialAndSpecialEquipmentAssignmentFormatEquipment(
            int warMaterialAndSpecialEquipmentAssignmentFormatId, string equipmentCode, int quantity)
        {
            WarMaterialAndSpecialEquipmentAssignmentFormatId = warMaterialAndSpecialEquipmentAssignmentFormatId;
            EquipmentCode = equipmentCode;
            Quantity = quantity;
        }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatEquipment Create(
            int warMaterialAndSpecialEquipmentAssignmentFormatId, string equipmentCode, int quantity)
        {
            return new(warMaterialAndSpecialEquipmentAssignmentFormatId, equipmentCode, quantity);
        }
    }
}
