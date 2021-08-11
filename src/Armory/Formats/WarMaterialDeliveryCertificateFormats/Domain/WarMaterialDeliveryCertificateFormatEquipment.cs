using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatEquipment
    {
        public WarMaterialDeliveryCertificateFormatEquipment(WarMaterialDeliveryCertificateFormat format,
            string equipmentCode, int quantity)
        {
            Format = format;
            EquipmentCode = equipmentCode;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatEquipment()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string EquipmentCode { get; set; }
        [ForeignKey("EquipmentCode")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatEquipment Create(WarMaterialDeliveryCertificateFormat format,
            string equipmentCode, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatEquipment(format, equipmentCode, quantity);
        }
    }
}
