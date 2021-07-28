using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Explosives.Domain;

namespace Armory.Formats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatExplosive
    {
        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string ExplosiveCode { get; set; }
        [ForeignKey("ExplosiveCode")] public Explosive Equipment { get; set; }

        public int Quantity { get; set; }

        public WarMaterialAndSpecialEquipmentAssignmentFormatExplosive(
            int warMaterialAndSpecialEquipmentAssignmentFormatId, string explosiveCode, int quantity)
        {
            WarMaterialAndSpecialEquipmentAssignmentFormatId = warMaterialAndSpecialEquipmentAssignmentFormatId;
            ExplosiveCode = explosiveCode;
            Quantity = quantity;
        }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatExplosive Create(
            int warMaterialAndSpecialEquipmentAssignmentFormatId, string explosiveCode, int quantity)
        {
            return new(warMaterialAndSpecialEquipmentAssignmentFormatId, explosiveCode, quantity);
        }
    }
}
