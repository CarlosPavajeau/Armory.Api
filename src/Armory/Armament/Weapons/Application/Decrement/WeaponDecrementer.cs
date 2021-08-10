using System.Threading.Tasks;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.Decrement
{
    public class WeaponDecrementer
    {
        private readonly WeaponFinder _finder;
        private readonly IWeaponsRepository _repository;

        public WeaponDecrementer(WeaponFinder finder, IWeaponsRepository repository)
        {
            _finder = finder;
            _repository = repository;
        }

        public async Task Decrement(string weaponCode)
        {
            var weapon = await _finder.Find(weaponCode);
            if (weapon == null)
            {
                throw new WeaponNotFound();
            }

            --weapon.QuantityAvailable;
            await _repository.Update(weapon);
        }
    }
}
