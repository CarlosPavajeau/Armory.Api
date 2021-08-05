using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatAmmunition
    {
        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string AmmunitionCode { get; set; }
        [ForeignKey("AmmunitionCode")] public Ammunition Ammunition { get; set; }

        public int Quantity { get; set; }

        public WarMaterialDeliveryCertificateFormatAmmunition(int warMaterialDeliveryCertificateFormatId,
            string ammunitionCode, int quantity)
        {
            WarMaterialDeliveryCertificateFormatId = warMaterialDeliveryCertificateFormatId;
            AmmunitionCode = ammunitionCode;
            Quantity = quantity;
        }

        public static WarMaterialDeliveryCertificateFormatAmmunition Create(int warMaterialDeliveryCertificateFormatId,
            string ammunitionCode, int quantity)
        {
            return new(warMaterialDeliveryCertificateFormatId, ammunitionCode, quantity);
        }
    }
}
