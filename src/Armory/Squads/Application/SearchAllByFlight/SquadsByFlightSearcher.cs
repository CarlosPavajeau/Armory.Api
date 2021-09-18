using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.SearchAllByFlight
{
    public class SquadsByFlightSearcher
    {
        private readonly ISquadsRepository _repository;

        public SquadsByFlightSearcher(ISquadsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Squad>> SearchAllByFlight(string flightCode)
        {
            return await _repository.SearchAllByFlight(flightCode);
        }
    }
}
