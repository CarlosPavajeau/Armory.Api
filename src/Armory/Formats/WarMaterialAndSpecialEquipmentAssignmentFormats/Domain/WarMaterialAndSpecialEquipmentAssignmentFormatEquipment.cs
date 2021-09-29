using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatEquipment
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatEquipment(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string equipmentSerial, int quantity)
        {
            Format = format;
            EquipmentSerial = equipmentSerial;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatEquipment()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string EquipmentSerial { get; set; }
        [ForeignKey("EquipmentSerial")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatEquipment Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string equipmentSerial, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatEquipment(format, equipmentSerial, quantity);
        }
    }
}
