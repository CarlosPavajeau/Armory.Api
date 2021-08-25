using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.SearchAll
{
    public class WeaponSearcher
    {
        private readonly IWeaponsRepository _repository;

        public WeaponSearcher(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Weapon>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
