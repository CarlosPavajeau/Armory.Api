using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormatEquipment
    {
        public WarMaterialDeliveryCertificateFormatEquipment(WarMaterialDeliveryCertificateFormat format,
            string equipmentSerial, int quantity)
        {
            Format = format;
            EquipmentSerial = equipmentSerial;
            Quantity = quantity;
        }

        private WarMaterialDeliveryCertificateFormatEquipment()
        {
        }

        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string EquipmentSerial { get; set; }
        [ForeignKey("EquipmentSerial")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public static WarMaterialDeliveryCertificateFormatEquipment Create(WarMaterialDeliveryCertificateFormat format,
            string equipmentSerial, int quantity)
        {
            return new WarMaterialDeliveryCertificateFormatEquipment(format, equipmentSerial, quantity);
        }
    }
}
