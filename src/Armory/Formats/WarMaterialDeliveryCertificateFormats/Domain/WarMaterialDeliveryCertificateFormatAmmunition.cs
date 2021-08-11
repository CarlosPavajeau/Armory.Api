using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatAmmunition
    {
        public WarMaterialDeliveryCertificateFormatAmmunition(WarMaterialDeliveryCertificateFormat format,
            string ammunitionCode, int quantity)
        {
            Format = format;
            AmmunitionCode = ammunitionCode;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatAmmunition()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string AmmunitionCode { get; set; }
        [ForeignKey("AmmunitionCode")] public Ammunition Ammunition { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatAmmunition Create(WarMaterialDeliveryCertificateFormat format,
            string ammunitionCode, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatAmmunition(format, ammunitionCode, quantity);
        }
    }
}
