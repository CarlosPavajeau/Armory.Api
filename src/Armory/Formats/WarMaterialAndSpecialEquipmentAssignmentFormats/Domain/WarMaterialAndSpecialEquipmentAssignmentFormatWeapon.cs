using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatWeapon
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatWeapon(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string weaponSeries)
        {
            Format = format;
            WeaponSeries = weaponSeries;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatWeapon()
        {
        }

        [Key] public int Id { get; set; }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string WeaponSeries { get; set; }
        [ForeignKey("WeaponSeries")] public Weapon Weapon { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatWeapon Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string weaponCode)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatWeapon(format, weaponCode);
        }
    }
}
