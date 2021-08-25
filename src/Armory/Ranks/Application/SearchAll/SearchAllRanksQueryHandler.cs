using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Ranks.Application.SearchAll
{
    public class SearchAllRanksQueryHandler : IQueryHandler<SearchAllRanksQuery, IEnumerable<RankResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AllRanksSearcher _searcher;

        public SearchAllRanksQueryHandler(AllRanksSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RankResponse>> Handle(SearchAllRanksQuery request,
            CancellationToken cancellationToken)
        {
            var ranks = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<RankResponse>>(ranks);
        }
    }
}
