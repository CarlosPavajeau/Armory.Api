namespace Armory.Formats.AssignedWeaponMagazineFormats.Application
{
    public class AssignedWeaponMagazineFormatItemResponse
    {
        public int Id { get; init; }
        public string TroopId { get; init; }
        public string WeaponCode { get; init; }
        public bool SafetyCartridge { get; init; }
        public bool VerifiedInPhysical { get; init; }
        public bool Novelty { get; init; }
        public int AmmunitionQuantity { get; init; }
        public string AmmunitionLot { get; init; }
        public string Observations { get; init; }
    }
}
