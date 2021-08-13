using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.Create
{
    public class WeaponCreator
    {
        private readonly IWeaponsRepository _repository;

        public WeaponCreator(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string type, string mark, string model, string caliber, string series,
            string lot, int numberOfProviders, int providerCapacity)
        {
            var weapon = Weapon.Create(code, type, mark, model, caliber, series, lot, numberOfProviders,
                providerCapacity);
            await _repository.Save(weapon);
        }
    }
}
