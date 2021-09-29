using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.SearchAllByFlight
{
    public class AmmunitionByFlightSearcher
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionByFlightSearcher(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Ammunition>> SearchAllByFlight(string flightCode)
        {
            return await _repository.SearchAllByFlight(flightCode);
        }
    }
}
