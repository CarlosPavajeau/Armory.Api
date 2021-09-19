using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Troopers.Application.SearchAllByFireteam
{
    public class
        SearchAllTroopersByFireteamQueryHandler : IQueryHandler<SearchAllTroopersByFireteamQuery,
            IEnumerable<TroopResponse>>
    {
        private readonly IMapper _mapper;
        private readonly TroopersByFireteamSearcher _searcher;

        public SearchAllTroopersByFireteamQueryHandler(TroopersByFireteamSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TroopResponse>> Handle(SearchAllTroopersByFireteamQuery request,
            CancellationToken cancellationToken)
        {
            var troopers = await _searcher.SearchAllByFireteam(request.FireteamCode);

            return _mapper.Map<IEnumerable<TroopResponse>>(troopers);
        }
    }
}
