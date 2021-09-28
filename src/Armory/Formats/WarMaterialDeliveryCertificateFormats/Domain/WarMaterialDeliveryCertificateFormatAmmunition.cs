using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatAmmunition
    {
        public WarMaterialDeliveryCertificateFormatAmmunition(WarMaterialDeliveryCertificateFormat format,
            string ammunitionLot, int quantity)
        {
            Format = format;
            AmmunitionLot = ammunitionLot;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatAmmunition()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string AmmunitionLot { get; set; }
        [ForeignKey("AmmunitionLot")] public Ammunition Ammunition { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatAmmunition Create(WarMaterialDeliveryCertificateFormat format,
            string ammunitionLot, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatAmmunition(format, ammunitionLot, quantity);
        }
    }
}
