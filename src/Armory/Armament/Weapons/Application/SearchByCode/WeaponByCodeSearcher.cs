using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.SearchByCode
{
    public class WeaponByCodeSearcher
    {
        private readonly IWeaponsRepository _repository;

        public WeaponByCodeSearcher(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task<WeaponResponse> Search(string code)
        {
            var weapon = await _repository.Find(code);
            return weapon == null ? null : WeaponResponse.FromAggregate(weapon);
        }
    }
}
