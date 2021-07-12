using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.SearchAll
{
    public class SearchAllDegreesQueryHandler : IQueryHandler<SearchAllDegreesQuery, IEnumerable<DegreeResponse>>
    {
        private readonly AllDegreesSearcher _searcher;

        public SearchAllDegreesQueryHandler(AllDegreesSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<DegreeResponse>> Handle(SearchAllDegreesQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
