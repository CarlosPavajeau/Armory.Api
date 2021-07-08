using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application
{
    public class WeaponResponse
    {
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

        public WeaponResponse(string code, string type, string mark, string model, string caliber, string series,
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

        public static WeaponResponse FromAggregate(Weapon weapon)
        {
            return new(weapon.Code, weapon.Type, weapon.Mark, weapon.Model, weapon.Caliber, weapon.Series, weapon.Lot,
                weapon.NumberOfProviders, weapon.ProviderCapacity, weapon.QuantityAvailable);
        }
    }
}
