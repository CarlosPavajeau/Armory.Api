using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string ammunitionLot, int quantity)
        {
            Format = format;
            AmmunitionLot = ammunitionLot;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string AmmunitionLot { get; set; }
        [ForeignKey("AmmunitionLot")] public Ammunition Ammunition { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string ammunitionLot, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition(format, ammunitionLot, quantity);
        }
    }
}
