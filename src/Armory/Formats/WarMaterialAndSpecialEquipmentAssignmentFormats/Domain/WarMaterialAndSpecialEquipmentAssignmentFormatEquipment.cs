using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatEquipment
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatEquipment(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string equipmentSeries, int quantity)
        {
            Format = format;
            EquipmentSeries = equipmentSeries;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatEquipment()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string EquipmentSeries { get; set; }
        [ForeignKey("EquipmentSeries")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatEquipment Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string equipmentSeries, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatEquipment(format, equipmentSeries, quantity);
        }
    }
}
