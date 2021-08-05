using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition
    {
        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string AmmunitionCode { get; set; }
        [ForeignKey("AmmunitionCode")] public Ammunition Ammunition { get; set; }

        public int Quantity { get; set; }

        public WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition(
            int warMaterialAndSpecialEquipmentAssignmentFormatId, string ammunitionCode, int quantity)
        {
            WarMaterialAndSpecialEquipmentAssignmentFormatId = warMaterialAndSpecialEquipmentAssignmentFormatId;
            AmmunitionCode = ammunitionCode;
            Quantity = quantity;
        }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition Create(
            int warMaterialAndSpecialEquipmentAssignmentFormatId, string ammunitionCode, int quantity)
        {
            return new(warMaterialAndSpecialEquipmentAssignmentFormatId, ammunitionCode, quantity);
        }
    }
}
