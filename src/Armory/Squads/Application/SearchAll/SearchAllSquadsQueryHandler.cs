using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchAll
{
    public class SearchAllSquadsQueryHandler : IQueryHandler<SearchAllSquadsQuery, IEnumerable<SquadResponse>>
    {
        private readonly SquadsSearcher _searcher;

        public SearchAllSquadsQueryHandler(SquadsSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<SquadResponse>> Handle(SearchAllSquadsQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
