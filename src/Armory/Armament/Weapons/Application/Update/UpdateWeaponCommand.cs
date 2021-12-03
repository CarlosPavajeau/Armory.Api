using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Update
{
    public class UpdateWeaponCommand : Command
    {
        public string Type { get; init; }
        public string Mark { get; init; }
        public string Model { get; init; }
        public string Caliber { get; init; }
        public string Serial { get; set; }
        public int NumberOfProviders { get; init; }
        public int ProviderCapacity { get; init; }
    }
}
