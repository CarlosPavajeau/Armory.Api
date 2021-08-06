using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
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
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string equipmentCode, int quantity)
        {
            Format = format;
            EquipmentCode = equipmentCode;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatEquipment()
        {
        }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatEquipment Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string equipmentCode, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatEquipment(format, equipmentCode, quantity);
        }
    }
}
