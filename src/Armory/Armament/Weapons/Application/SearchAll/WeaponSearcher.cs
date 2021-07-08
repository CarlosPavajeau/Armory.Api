using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<WeaponResponse>> SearchAll()
        {
            var weapons = await _repository.SearchAll();
            return weapons.Select(WeaponResponse.FromAggregate);
        }
    }
}
