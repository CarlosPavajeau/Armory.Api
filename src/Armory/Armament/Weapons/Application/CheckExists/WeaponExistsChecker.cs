using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.CheckExists
{
    public class WeaponExistsChecker
    {
        private readonly IWeaponsRepository _repository;

        public WeaponExistsChecker(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string series)
        {
            return await _repository.Any(w => w.Series == series);
        }
    }
}
