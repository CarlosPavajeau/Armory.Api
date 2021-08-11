using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Explosives.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatExplosive
    {
        public WarMaterialDeliveryCertificateFormatExplosive(WarMaterialDeliveryCertificateFormat format,
            string explosiveCode, int quantity)
        {
            Format = format;
            ExplosiveCode = explosiveCode;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatExplosive()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string ExplosiveCode { get; set; }
        [ForeignKey("ExplosiveCode")] public Explosive Explosive { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatExplosive Create(WarMaterialDeliveryCertificateFormat format,
            string explosiveCode, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatExplosive(format, explosiveCode, quantity);
        }
    }
}
