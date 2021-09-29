using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatWeapon
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatWeapon(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string weaponSerial)
        {
            Format = format;
            WeaponSerial = weaponSerial;
        }

        private WarMaterialAndSpecialEquipmentAssignmentFormatWeapon()
        {
        }

        [Key] public int Id { get; set; }

        public int WarMaterialAndSpecialEquipmentAssignmentFormatId { get; set; }

        [ForeignKey("WarMaterialAndSpecialEquipmentAssignmentFormatId")]
        public WarMaterialAndSpecialEquipmentAssignmentFormat Format { get; set; }

        public string WeaponSerial { get; set; }
        [ForeignKey("WeaponSerial")] public Weapon Weapon { get; set; }

        public static WarMaterialAndSpecialEquipmentAssignmentFormatWeapon Create(
            WarMaterialAndSpecialEquipmentAssignmentFormat format, string weaponSerial)
        {
            return new WarMaterialAndSpecialEquipmentAssignmentFormatWeapon(format, weaponSerial);
        }
    }
}
