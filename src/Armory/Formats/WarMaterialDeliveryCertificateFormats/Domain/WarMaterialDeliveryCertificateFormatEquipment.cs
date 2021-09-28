using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatEquipment
    {
        public WarMaterialDeliveryCertificateFormatEquipment(WarMaterialDeliveryCertificateFormat format,
            string equipmentSeries, int quantity)
        {
            Format = format;
            EquipmentSeries = equipmentSeries;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatEquipment()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string EquipmentSeries { get; set; }
        [ForeignKey("EquipmentSeries")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatEquipment Create(WarMaterialDeliveryCertificateFormat format,
            string equipmentSeries, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatEquipment(format, equipmentSeries, quantity);
        }
    }
}
