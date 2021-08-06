using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatWeapon
    {
        public WarMaterialDeliveryCertificateFormatWeapon(WarMaterialDeliveryCertificateFormat format,
            string weaponCode)
        {
            Format = format;
            WeaponCode = weaponCode;
        }

        private WarMaterialDeliveryCertificateFormatWeapon()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string WeaponCode { get; set; }
        [ForeignKey("ExplosiveCode")] public Weapon Weapon { get; set; }

        public static WarMaterialDeliveryCertificateFormatWeapon Create(WarMaterialDeliveryCertificateFormat format,
            string weaponCode)
        {
            return new WarMaterialDeliveryCertificateFormatWeapon(format, weaponCode);
        }
    }
}
