using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Explosives.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatExplosive
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatExplosive(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string explosiveSerial, int quantity)
        {
            Format = format;
            ExplosiveSerial = explosiveSerial;
            Quantity = quantity;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatExplosive()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string ExplosiveSerial { get; set; }
        [ForeignKey("ExplosiveSerial")] public Explosive Explosive { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatExplosive Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string explosiveSerial, int quantity)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatExplosive(format, explosiveSerial, quantity);
        }
    }
}
