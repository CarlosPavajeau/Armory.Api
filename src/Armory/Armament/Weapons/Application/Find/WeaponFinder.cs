using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.Find
{
    public class WeaponFinder
    {
        private readonly IWeaponsRepository _repository;

        public WeaponFinder(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Weapon> Find(string serial, bool noTracking)
        {
            return await _repository.Find(serial, noTracking);
        }

        public async Task<Weapon> Find(string code)
        {
            return await Find(code, true);
        }
    }
}
