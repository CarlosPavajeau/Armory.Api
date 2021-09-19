using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Fireteams.Domain;

namespace Armory.Fireteams.Application.SearchAllByFlight
{
    public class FireteamsByFlightSearcher
    {
        private readonly IFireteamsRepository _repository;

        public FireteamsByFlightSearcher(IFireteamsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Fireteam>> SearchAllByFlight(string flightCode)
        {
            return await _repository.SearchAllByFlight(flightCode);
        }
    }
}
