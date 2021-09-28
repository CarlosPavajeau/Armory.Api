using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Weapons.Domain;

namespace Armory.Armament.Weapons.Application.SearchAllByFlight
{
    public class WeaponsByFlightSearcher
    {
        private readonly IWeaponsRepository _repository;

        public WeaponsByFlightSearcher(IWeaponsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Weapon>> SearchAllByFlight(string flightCode)
        {
            return await _repository.SearchAllByFlight(flightCode);
        }
    }
}
