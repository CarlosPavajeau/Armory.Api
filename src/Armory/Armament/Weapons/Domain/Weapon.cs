using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Troopers.Domain;

namespace Armory.Armament.Weapons.Domain
{
    public class Weapon
    {
        public Weapon(string code, string type, string mark, string model, string caliber, string series,
            int numberOfProviders, int providerCapacity)
        {
            Code = code;
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Series = series;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
        }

        internal Weapon()
        {
        }

        [Key] [MaxLength(50)] public string Code { get; set; }
        [Required] [MaxLength(128)] public string Type { get; set; }
        [Required] [MaxLength(256)] public string Mark { get; set; }
        [Required] [MaxLength(256)] public string Model { get; set; }
        [Required] [MaxLength(256)] public string Caliber { get; set; }
        [Required] [MaxLength(256)] public string Series { get; set; }
        [Required] public int NumberOfProviders { get; set; }
        [Required] public int ProviderCapacity { get; set; }
        [Required] public WeaponState State { get; set; }

        public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Owner { get; set; }

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>
            WarMaterialAndSpecialEquipmentAssignmentFormatWeapons { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>();

        public ICollection<WarMaterialDeliveryCertificateFormatWeapon> WarMaterialDeliveryCertificateFormatWeapons
        {
            get;
            set;
        } =
            new HashSet<WarMaterialDeliveryCertificateFormatWeapon>();

        public void Update(string type, string mark, string model, string caliber, string series, int numberOfProviders,
            int providerCapacity)
        {
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Series = series;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
        }
    }
}
