using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Update
{
    public class UpdateWeaponCommand : Command
    {
        public UpdateWeaponCommand(string code, string type, string mark, string model, string caliber, string series,
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

        public string Code { get; }
        public string Type { get; }
        public string Mark { get; }
        public string Model { get; }
        public string Caliber { get; }
        public string Series { get; }
        public int NumberOfProviders { get; }
        public int ProviderCapacity { get; }
    }
}
