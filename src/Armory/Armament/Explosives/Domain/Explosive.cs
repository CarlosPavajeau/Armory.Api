using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Flights.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;

namespace Armory.Armament.Explosives.Domain
{
    public class Explosive
    {
        public Explosive(string type, string caliber, string mark, string lot, string serial,
            int quantityAvailable)
        {
            Type = type;
            Caliber = caliber;
            Mark = mark;
            Lot = lot;
            Serial = serial;
            QuantityAvailable = quantityAvailable;
        }


        [Key] [MaxLength(256)] public string Serial { get; set; }
        [Required] [MaxLength(128)] public string Type { get; set; }
        [Required] [MaxLength(256)] public string Caliber { get; set; }
        [Required] [MaxLength(256)] public string Mark { get; set; }
        [Required] [MaxLength(256)] public string Lot { get; set; }
        [Required] public int QuantityAvailable { get; set; }

        public string FlightCode { get; set; }
        [ForeignKey("FlightCode")] public Flight Flight { get; set; }

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatExplosive>
            WarMaterialAndSpecialEquipmentAssignmentFormatExplosives { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatExplosive>();

        public ICollection<WarMaterialDeliveryCertificateFormatExplosive>
            WarMaterialDeliveryCertificateFormatExplosives { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormatExplosive>();

        public void Update(string type, string caliber, string mark, string lot, string series, int quantityAvailable)
        {
            Type = type;
            Caliber = caliber;
            Mark = mark;
            Lot = lot;
            Serial = series;
            QuantityAvailable = quantityAvailable;
        }
    }
}
