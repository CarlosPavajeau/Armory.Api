using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Ranks.Application.SearchAll
{
    public class SearchAllRanksQueryHandler : IQueryHandler<SearchAllRanksQuery, IEnumerable<RankResponse>>
    {
        private readonly AllRanksSearcher _searcher;

        public SearchAllRanksQueryHandler(AllRanksSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<RankResponse>> Handle(SearchAllRanksQuery request,
            CancellationToken cancellationToken)
        {
            return await _searcher.SearchAll();
        }
    }
}
