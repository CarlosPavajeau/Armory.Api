using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatWeapon
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatWeapon(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string weaponCode)
        {
            Format = format;
            WeaponCode = weaponCode;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatWeapon()
        {
        }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string WeaponCode { get; set; }
        [ForeignKey("WeaponCode")] public Weapon Weapon { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatWeapon Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string weaponCode)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatWeapon(format, weaponCode);
        }
    }
}
