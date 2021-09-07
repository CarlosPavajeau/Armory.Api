namespace Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests
{
    public class AddAssignedWeaponMagazineFormatItemRequest
    {
        public int FormatId { get; set; }
        public string TroopId { get; set; }
        public string WeaponCode { get; set; }
        public bool SafetyCartridge { get; set; }
        public bool VerifiedInPhysical { get; set; }
        public bool Novelty { get; set; }
        public int AmmunitionQuantity { get; set; }
        public string AmmunitionLot { get; set; }
        public string Observations { get; set; }
    }
}
