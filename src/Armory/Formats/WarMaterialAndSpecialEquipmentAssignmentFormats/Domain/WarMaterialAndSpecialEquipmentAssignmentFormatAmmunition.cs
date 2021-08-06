using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string ammunitionCode, int quantity)
        {
            Format = format;
            AmmunitionCode = ammunitionCode;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string AmmunitionCode { get; set; }
        [ForeignKey("AmmunitionCode")] public Ammunition Ammunition { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string ammunitionCode, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition(format, ammunitionCode, quantity);
        }
    }
}
