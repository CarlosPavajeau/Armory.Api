using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application
{
    public class WeaponResponse
    {
        public WeaponResponse(string code, string type, string mark, string model, string caliber, string series,
            string lot, int numberOfProviders, int providerCapacity, string ownerId, string ownerName)
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
            OwnerId = ownerId;
            OwnerName = ownerName;
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
        public string OwnerId { get; }
        public string OwnerName { get; }

        public static WeaponResponse FromAggregate(Weapon weapon)
        {
            var ownerId = weapon.Owner != null ? weapon.Owner.Id : string.Empty;
            var ownerName = weapon.Owner != null
                ? $"{weapon.Owner.FirstName} {weapon.Owner.SecondName} {weapon.Owner.LastName} {weapon.Owner.SecondLastName}"
                : string.Empty;

            return new WeaponResponse(weapon.Code, weapon.Type, weapon.Mark, weapon.Model, weapon.Caliber,
                weapon.Series, weapon.Lot, weapon.NumberOfProviders, weapon.ProviderCapacity, ownerId, ownerName);
        }
    }
}
