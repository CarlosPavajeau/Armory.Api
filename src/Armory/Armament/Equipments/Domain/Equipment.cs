using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Flights.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Troopers.Domain;

namespace Armory.Armament.Equipments.Domain
{
    public class Equipment
    {
        public Equipment(string type, string model, string serial, int quantityAvailable)
        {
            Type = type;
            Model = model;
            Serial = serial;
            QuantityAvailable = quantityAvailable;
        }

        [Key] [MaxLength(256)] public string Serial { get; set; }
        [Required] [MaxLength(128)] public string Type { get; set; }
        [Required] [MaxLength(256)] public string Model { get; set; }
        [Required] public int QuantityAvailable { get; set; }

        public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Holder { get; set; }

        public string FlightCode { get; set; }
        [ForeignKey("FlightCode")] public Flight Flight { get; set; }

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatEquipment>
            WarMaterialAndSpecialEquipmentAssignmentFormatEquipments { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatEquipment>();

        public ICollection<WarMaterialDeliveryCertificateFormatEquipment>
            WarMaterialDeliveryCertificateFormatEquipments { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormatEquipment>();

        public void Update(string type, string model, string series, int quantityAvailable)
        {
            Type = type;
            Model = model;
            Serial = series;
            QuantityAvailable = quantityAvailable;
        }
    }
}
