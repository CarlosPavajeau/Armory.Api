using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Explosives.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatExplosive
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatExplosive(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string explosiveCode, int quantity)
        {
            Format = format;
            ExplosiveCode = explosiveCode;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatExplosive()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string ExplosiveCode { get; set; }
        [ForeignKey("ExplosiveCode")] public Explosive Explosive { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatExplosive Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string explosiveCode, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatExplosive(format, explosiveCode, quantity);
        }
    }
}
