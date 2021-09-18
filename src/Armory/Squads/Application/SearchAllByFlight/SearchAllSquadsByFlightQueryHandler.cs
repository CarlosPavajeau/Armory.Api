using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Squads.Application.SearchAllByFlight
{
    public class
        SearchAllSquadsByFlightQueryHandler : IQueryHandler<SearchAllSquadsByFlightQuery,
            IEnumerable<SquadResponse>>
    {
        private readonly IMapper _mapper;
        private readonly SquadsByFlightSearcher _searcher;

        public SearchAllSquadsByFlightQueryHandler(SquadsByFlightSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SquadResponse>> Handle(SearchAllSquadsByFlightQuery request,
            CancellationToken cancellationToken)
        {
            var squads = await _searcher.SearchAllByFlight(request.FlightCode);
            return _mapper.Map<IEnumerable<SquadResponse>>(squads);
        }
    }
}
