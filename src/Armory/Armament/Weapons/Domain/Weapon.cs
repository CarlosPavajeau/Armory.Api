using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;

namespace Armory.Armament.Weapons.Domain
{
    public class Weapon
    {
        [Key, MaxLength(50)] public string Code { get; set; }
        [Required, MaxLength(128)] public string Type { get; set; }
        [Required, MaxLength(256)] public string Mark { get; set; }
        [Required, MaxLength(256)] public string Model { get; set; }
        [Required, MaxLength(256)] public string Caliber { get; set; }
        [Required, MaxLength(256)] public string Series { get; set; }
        [Required, MaxLength(256)] public string Lot { get; set; }
        [Required] public int NumberOfProviders { get; set; }
        [Required] public int ProviderCapacity { get; set; }
        [Required] public int QuantityAvailable { get; set; }

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormat>
            WarMaterialAndSpecialEquipmentAssignmentFormats { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormat>();

        public ICollection<WarMaterialDeliveryCertificateFormat> WarMaterialDeliveryCertificateFormats { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormat>();

        public Weapon(string code, string type, string mark, string model, string caliber, string series, string lot,
            int numberOfProviders, int providerCapacity, int quantityAvailable)
        {
            Code = code;
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
            QuantityAvailable = quantityAvailable;
        }

        private Weapon()
        {
        }

        public void Update(string type, string mark, string model, string caliber, string series,
            string lot, int numberOfProviders, int providerCapacity, int quantityAvailable)
        {
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
            QuantityAvailable = quantityAvailable;
        }

        public static Weapon Create(string code, string type, string mark, string model, string caliber, string series,
            string lot, int numberOfProviders, int providerCapacity, int quantityAvailable)
        {
            return new(code, type, mark, model, caliber, series, lot, numberOfProviders, providerCapacity,
                quantityAvailable);
        }
    }
}
