using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.SearchAllByFlight
{
    public class ExplosivesByFlightSearcher
    {
        private readonly IExplosivesRepository _repository;

        public ExplosivesByFlightSearcher(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Explosive>> SearchAllByFlight(string flightCode)
        {
            return await _repository.SearchAllByFlight(flightCode);
        }
    }
}
