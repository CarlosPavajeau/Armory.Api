using System.Threading.Tasks;
using Armory.Flights.Domain;

namespace Armory.Flights.Application.CheckExists
{
    public class FlightExistsChecker
    {
        private readonly IFlightsRepository _repository;

        public FlightExistsChecker(IFlightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string code)
        {
            return await _repository.Any(s => s.Code == code);
        }
    }
}
