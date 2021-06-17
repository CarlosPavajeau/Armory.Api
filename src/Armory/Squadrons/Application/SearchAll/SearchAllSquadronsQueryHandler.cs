using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.SearchAll
{
    public class SearchAllSquadronsQueryHandler : IQueryHandler<SearchAllSquadronsQuery, IEnumerable<SquadronResponse>>
    {
        private readonly SquadronsSearcher _searcher;

        public SearchAllSquadronsQueryHandler(SquadronsSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<SquadronResponse>> Handle(SearchAllSquadronsQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
