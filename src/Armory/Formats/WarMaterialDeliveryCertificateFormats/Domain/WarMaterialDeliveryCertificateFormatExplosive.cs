using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Explosives.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatExplosive
    {
        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string ExplosiveCode { get; set; }
        [ForeignKey("ExplosiveCode")] public Explosive Explosive { get; set; }

        public int Quantity { get; set; }

        public WarMaterialDeliveryCertificateFormatExplosive(int warMaterialDeliveryCertificateFormatId,
            string explosiveCode, int quantity)
        {
            WarMaterialDeliveryCertificateFormatId = warMaterialDeliveryCertificateFormatId;
            ExplosiveCode = explosiveCode;
            Quantity = quantity;
        }

        public static WarMaterialDeliveryCertificateFormatExplosive Create(int warMaterialDeliveryCertificateFormatId,
            string ammunitionCode, int quantity)
        {
            return new(warMaterialDeliveryCertificateFormatId, ammunitionCode, quantity);
        }
    }
}
