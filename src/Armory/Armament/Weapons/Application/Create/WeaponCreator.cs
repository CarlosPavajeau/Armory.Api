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

        public async Task<Weapon> Create(string code, string type, string mark, string model, string caliber,
            string series, int numberOfProviders, int providerCapacity)
        {
            var weapon = Weapon.Create(code, type, mark, model, caliber, series, numberOfProviders, providerCapacity);
            await _repository.Save(weapon);

            return weapon;
        }
    }
}
