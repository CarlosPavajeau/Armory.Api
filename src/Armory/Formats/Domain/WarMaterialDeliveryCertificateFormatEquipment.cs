using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;

namespace Armory.Formats.Domain
{
    public class WarMaterialDeliveryCertificateFormatEquipment
    {
        public int WarMaterialDeliveryCertificateFormatId { get; set; }

        [ForeignKey("WarMaterialDeliveryCertificateFormatId")]
        public WarMaterialDeliveryCertificateFormat Format { get; set; }

        public string EquipmentCode { get; set; }
        [ForeignKey("EquipmentCode")] public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

        public WarMaterialDeliveryCertificateFormatEquipment(int warMaterialDeliveryCertificateFormatId,
            string equipmentCode, int quantity)
        {
            WarMaterialDeliveryCertificateFormatId = warMaterialDeliveryCertificateFormatId;
            EquipmentCode = equipmentCode;
            Quantity = quantity;
        }

        public static WarMaterialDeliveryCertificateFormatEquipment Create(int warMaterialDeliveryCertificateFormatId,
            string equipmentCode, int quantity)
        {
            return new(warMaterialDeliveryCertificateFormatId, equipmentCode, quantity);
        }
    }
}
