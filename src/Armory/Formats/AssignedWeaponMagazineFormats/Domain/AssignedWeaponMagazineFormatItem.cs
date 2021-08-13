using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Weapons.Domain;
using Armory.Troopers.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    public class AssignedWeaponMagazineFormatItem
    {
        public AssignedWeaponMagazineFormatItem(string troopId, string weaponCode, bool cartridgeOfLife,
            bool verifiedInPhysical, bool novelty, string observations)
        {
            TroopId = troopId;
            WeaponCode = weaponCode;
            CartridgeOfLife = cartridgeOfLife;
            VerifiedInPhysical = verifiedInPhysical;
            Novelty = novelty;
            Observations = observations;
        }

        [Key] public int Id { get; set; }

        [Required] public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Troop { get; set; }

        [Required] public string WeaponCode { get; set; }
        [ForeignKey("WeaponCode")] public Weapon Weapon { get; set; }

        public bool CartridgeOfLife { get; set; }
        public bool VerifiedInPhysical { get; set; }
        public bool Novelty { get; set; }
        [MaxLength(512)] public string Observations { get; set; }

        [Required] public int AssignedWeaponMagazineFormatId { get; set; }

        [ForeignKey("AssignedWeaponMagazineFormatId")]
        public AssignedWeaponMagazineFormat AssignedWeaponMagazineFormat { get; set; }

        public static AssignedWeaponMagazineFormatItem Create(string troopId, string weaponCode, bool cartridgeOfLife,
            bool verifiedInPhysical, bool novelty, string observations)
        {
            return new AssignedWeaponMagazineFormatItem(troopId, weaponCode, cartridgeOfLife, verifiedInPhysical,
                novelty, observations);
        }
    }
}
