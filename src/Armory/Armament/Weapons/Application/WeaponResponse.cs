namespace Armory.Armament.Weapons.Application
{
    public class WeaponResponse
    {
        public string Serial { get; init; }
        public string Type { get; init; }
        public string Mark { get; init; }
        public string Model { get; init; }
        public string Caliber { get; init; }
        public int NumberOfProviders { get; init; }
        public int ProviderCapacity { get; init; }
        public string OwnerId { get; init; }
        public string OwnerName { get; init; }
    }
}
