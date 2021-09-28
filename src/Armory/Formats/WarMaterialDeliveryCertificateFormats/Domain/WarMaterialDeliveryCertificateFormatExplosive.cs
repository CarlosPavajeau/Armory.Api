using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Explosives.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatExplosive
    {
        public WarMaterialDeliveryCertificateFormatExplosive(WarMaterialDeliveryCertificateFormat format,
            string explosiveSerial, int quantity)
        {
            Format = format;
            ExplosiveSerial = explosiveSerial;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatExplosive()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string ExplosiveSerial { get; set; }
        [ForeignKey("ExplosiveSerial")] public Explosive Explosive { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatExplosive Create(WarMaterialDeliveryCertificateFormat format,
            string explosiveSerial, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatExplosive(format, explosiveSerial, quantity);
        }
    }
}
