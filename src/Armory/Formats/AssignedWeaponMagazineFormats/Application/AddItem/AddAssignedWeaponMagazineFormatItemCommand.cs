using Armory.Shared.Domain.Bus.Command;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem
{
    public class AddAssignedWeaponMagazineFormatItemCommand : Command
    {
        public AddAssignedWeaponMagazineFormatItemCommand(int formatId, string troopId, string weaponCode,
            bool cartridgeOfLife, bool verifiedInPhysical, bool novelty, int ammunitionQuantity, string ammunitionLot,
            string observations)
        {
            FormatId = formatId;
            TroopId = troopId;
            WeaponCode = weaponCode;
            CartridgeOfLife = cartridgeOfLife;
            VerifiedInPhysical = verifiedInPhysical;
            Novelty = novelty;
            AmmunitionQuantity = ammunitionQuantity;
            AmmunitionLot = ammunitionLot;
            Observations = observations;
        }

        public int FormatId { get; }
        public string TroopId { get; }
        public string WeaponCode { get; }
        public bool CartridgeOfLife { get; }
        public bool VerifiedInPhysical { get; }
        public bool Novelty { get; }
        public int AmmunitionQuantity { get; }
        public string AmmunitionLot { get; }
        public string Observations { get; }
    }
}
