using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Flights.Application.SearchAll
{
    public class SearchAllFlightsQueryHandler : IQueryHandler<SearchAllFlightsQuery, IEnumerable<FlightResponse>>
    {
        private readonly IMapper _mapper;
        private readonly FlightsSearcher _searcher;

        public SearchAllFlightsQueryHandler(FlightsSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightResponse>> Handle(SearchAllFlightsQuery request,
            CancellationToken cancellationToken)
        {
            var flights = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<FlightResponse>>(flights);
        }
    }
}
