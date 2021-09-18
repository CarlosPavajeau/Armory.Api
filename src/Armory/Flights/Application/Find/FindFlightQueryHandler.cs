using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Flights.Application.Find
{
    public class FindFlightQueryHandler : IQueryHandler<FindFlightQuery, FlightResponse>
    {
        private readonly FlightFinder _finder;
        private readonly IMapper _mapper;

        public FindFlightQueryHandler(FlightFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<FlightResponse> Handle(FindFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await _finder.Find(request.Code);
            return flight == null ? null : _mapper.Map<FlightResponse>(flight);
        }
    }
}
