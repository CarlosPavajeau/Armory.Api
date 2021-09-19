using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Fireteams.Application.SearchAll
{
    public class SearchAllFireteamsQueryHandler : IQueryHandler<SearchAllFireteamsQuery, IEnumerable<FireteamResponse>>
    {
        private readonly IMapper _mapper;
        private readonly FireteamsSearcher _searcher;

        public SearchAllFireteamsQueryHandler(FireteamsSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FireteamResponse>> Handle(SearchAllFireteamsQuery request,
            CancellationToken cancellationToken)
        {
            var fireteams = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<FireteamResponse>>(fireteams);
        }
    }
}
