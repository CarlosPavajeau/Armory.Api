using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Create
{
    public class CreateWeaponCommand : Command
    {
        public CreateWeaponCommand(string code, string type, string mark, string model, string caliber, string series,
            string lot, int numberOfProviders, int providerCapacity, int quantityAvailable)
        {
            Code = code;
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
            QuantityAvailable = quantityAvailable;
        }

        public string Code { get; }
        public string Type { get; }
        public string Mark { get; }
        public string Model { get; }
        public string Caliber { get; }
        public string Series { get; }
        public string Lot { get; }
        public int NumberOfProviders { get; }
        public int ProviderCapacity { get; }
        public int QuantityAvailable { get; }
    }
}
