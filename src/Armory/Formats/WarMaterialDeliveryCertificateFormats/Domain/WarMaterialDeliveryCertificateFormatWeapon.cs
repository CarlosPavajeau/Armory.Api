using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatWeapon
    {
        public WarMaterialDeliveryCertificateFormatWeapon(WarMaterialDeliveryCertificateFormat format,
            string weaponSeries)
        {
            Format = format;
            WeaponSeries = weaponSeries;
        }

        private WarMaterialDeliveryCertificateFormatWeapon()
        {
        }

        [Key] public int Id { get; set; }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string WeaponSeries { get; set; }
        [ForeignKey("WeaponSeries")] public Weapon Weapon { get; set; }

        public static WarMaterialDeliveryCertificateFormatWeapon Create(WarMaterialDeliveryCertificateFormat format,
            string weaponCode)
        {
            return new WarMaterialDeliveryCertificateFormatWeapon(format, weaponCode);
        }
    }
}
