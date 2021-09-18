using System.Threading.Tasks;
using Armory.Flights.Domain;

namespace Armory.Flights.Application.Find
{
    public class FlightFinder
    {
        private readonly IFlightsRepository _repository;

        public FlightFinder(IFlightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Flight> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
