using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Fireteams.Application.SearchAllByFlight
{
    public class
        SearchAllFireteamsByFlightQueryHandler : IQueryHandler<SearchAllFireteamsByFlightQuery,
            IEnumerable<FireteamResponse>>
    {
        private readonly IMapper _mapper;
        private readonly FireteamsByFlightSearcher _searcher;

        public SearchAllFireteamsByFlightQueryHandler(FireteamsByFlightSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FireteamResponse>> Handle(SearchAllFireteamsByFlightQuery request,
            CancellationToken cancellationToken)
        {
            var fireteams = await _searcher.SearchAllByFlight(request.FlightCode);
            return _mapper.Map<IEnumerable<FireteamResponse>>(fireteams);
        }
    }
}
