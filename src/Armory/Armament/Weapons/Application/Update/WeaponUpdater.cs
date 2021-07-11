using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.Update
{
    public class WeaponUpdater
    {
        private readonly IWeaponsRepository _repository;

        public WeaponUpdater(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Weapon weapon, string type, string mark, string model, string caliber, string series,
            string lot, int numberOfProviders, int providerCapacity, int quantityAvailable)
        {
            weapon.Update(type, mark, model, caliber, series, lot, numberOfProviders, providerCapacity,
                quantityAvailable);
            await _repository.Update(weapon);
        }
    }
}
