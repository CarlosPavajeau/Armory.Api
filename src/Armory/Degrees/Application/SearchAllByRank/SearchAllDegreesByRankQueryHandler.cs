using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.SearchAllByRank
{
    public class
        SearchAllDegreesByRankQueryHandler : IQueryHandler<SearchAllDegreesByRankQuery, IEnumerable<DegreeResponse>>
    {
        private readonly DegreesByRankSearcher _searcher;

        public SearchAllDegreesByRankQueryHandler(DegreesByRankSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<DegreeResponse>> Handle(SearchAllDegreesByRankQuery query)
        {
            return await _searcher.SearchByRank(query.RankId);
        }
    }
}
