using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Flights.Domain;

namespace Armory.Flights.Application.SearchAll
{
    public class FlightsSearcher
    {
        private readonly IFlightsRepository _repository;

        public FlightsSearcher(IFlightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Flight>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
