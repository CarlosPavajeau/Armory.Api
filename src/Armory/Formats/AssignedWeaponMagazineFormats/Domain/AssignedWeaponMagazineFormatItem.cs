using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;
using Armory.Troopers.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    public class AssignedWeaponMagazineFormatItem
    {
        public AssignedWeaponMagazineFormatItem(string troopId, string weaponCode, bool cartridgeOfLife,
            bool verifiedInPhysical, bool novelty, int ammunitionQuantity, string ammunitionLot, string observations,
            AssignedWeaponMagazineFormat format)
        {
            TroopId = troopId;
            WeaponCode = weaponCode;
            CartridgeOfLife = cartridgeOfLife;
            VerifiedInPhysical = verifiedInPhysical;
            Novelty = novelty;
            AmmunitionQuantity = ammunitionQuantity;
            AmmunitionLot = ammunitionLot;
            Observations = observations;
            Format = format;
        }

        internal AssignedWeaponMagazineFormatItem()
        {
        }

        [Key] public int Id { get; set; }

        [Required] public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Troop { get; set; }

        [Required] public string WeaponCode { get; set; }
        [ForeignKey("WeaponCode")] public Weapon Weapon { get; set; }

        public bool CartridgeOfLife { get; set; }
        public bool VerifiedInPhysical { get; set; }
        public bool Novelty { get; set; }
        [Required] public int AmmunitionQuantity { get; set; }
        [Required] public string AmmunitionLot { get; set; }
        [MaxLength(512)] public string Observations { get; set; }

        [Required] public int AssignedWeaponMagazineFormatId { get; set; }

        [ForeignKey("AssignedWeaponMagazineFormatId")]
        public AssignedWeaponMagazineFormat Format { get; set; }

        public static AssignedWeaponMagazineFormatItem Create(string troopId, string weaponCode, bool cartridgeOfLife,
            bool verifiedInPhysical, bool novelty, int ammunitionQuantity, string ammunitionLot, string observations,
            AssignedWeaponMagazineFormat format)
        {
            return new AssignedWeaponMagazineFormatItem(troopId, weaponCode, cartridgeOfLife, verifiedInPhysical,
                novelty, ammunitionQuantity, ammunitionLot, observations, format);
        }
    }
}
