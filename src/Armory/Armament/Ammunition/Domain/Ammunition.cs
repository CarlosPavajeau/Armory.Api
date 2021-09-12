using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;

namespace Armory.Armament.Ammunition.Domain
{
    public class Ammunition
    {
        public Ammunition(string code, string type, string mark, string caliber, string series, string lot,
            int quantityAvailable)
        {
            Code = code;
            Type = type;
            Mark = mark;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            QuantityAvailable = quantityAvailable;
        }

        [Key] [MaxLength(50)] public string Code { get; set; }
        [Required] [MaxLength(128)] public string Type { get; set; }
        [Required] [MaxLength(256)] public string Mark { get; set; }
        [Required] [MaxLength(256)] public string Caliber { get; set; }
        [Required] [MaxLength(256)] public string Series { get; set; }
        [Required] [MaxLength(256)] public string Lot { get; set; }
        [Required] public int QuantityAvailable { get; set; }

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition>
            WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition>();

        public ICollection<WarMaterialDeliveryCertificateFormatAmmunition>
            WarMaterialDeliveryCertificateFormatAmmunition { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormatAmmunition>();

        public void Update(string type, string mark, string caliber, string series, string lot,
            int quantityAvailable)
        {
            Type = type;
            Mark = mark;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            QuantityAvailable = quantityAvailable;
        }
    }
}
