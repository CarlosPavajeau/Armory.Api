using System.Threading.Tasks;
using Armory.Flights.Domain;
using AutoMapper;

namespace Armory.Flights.Application.Create
{
    public class FlightCreator
    {
        private readonly IMapper _mapper;
        private readonly IFlightsRepository _repository;

        public FlightCreator(IFlightsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Create(CreateFlightCommand command)
        {
            var flight = _mapper.Map<Flight>(command);

            await _repository.Save(flight);
        }
    }
}
