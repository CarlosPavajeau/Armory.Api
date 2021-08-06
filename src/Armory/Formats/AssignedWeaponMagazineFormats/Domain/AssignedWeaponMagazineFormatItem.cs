using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Troopers.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    public class AssignedWeaponMagazineFormatItem
    {
        public AssignedWeaponMagazineFormatItem(string troopId, bool cartridgeOfLife, bool verifiedInPhysical,
            bool novelty, string observations)
        {
            TroopId = troopId;
            CartridgeOfLife = cartridgeOfLife;
            VerifiedInPhysical = verifiedInPhysical;
            Novelty = novelty;
            Observations = observations;
        }

        [Key] public int Id { get; set; }

        [Required] public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Troop { get; set; }

        public bool CartridgeOfLife { get; set; }
        public bool VerifiedInPhysical { get; set; }
        public bool Novelty { get; set; }
        [MaxLength(512)] public string Observations { get; set; }

        [Required] public int AssignedWeaponMagazineFormatId { get; set; }

        [ForeignKey("AssignedWeaponMagazineFormatId")]
        public AssignedWeaponMagazineFormat AssignedWeaponMagazineFormat { get; set; }

        public static AssignedWeaponMagazineFormatItem Create(string troopId, bool cartridgeOfLife,
            bool verifiedInPhysical,
            bool novelty, string observations)
        {
            return new AssignedWeaponMagazineFormatItem(troopId, cartridgeOfLife, verifiedInPhysical, novelty,
                observations);
        }
    }
}
