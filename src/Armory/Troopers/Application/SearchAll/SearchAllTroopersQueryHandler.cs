using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.SearchAll
{
    public class SearchAllTroopersQueryHandler : IQueryHandler<SearchAllTroopersQuery, IEnumerable<TroopResponse>>
    {
        private readonly AllTroopsSearcher _searcher;

        public SearchAllTroopersQueryHandler(AllTroopsSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<TroopResponse>> Handle(SearchAllTroopersQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
