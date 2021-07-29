using System.Collections.Generic;
using System.Threading;
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

        public async Task<IEnumerable<DegreeResponse>> Handle(SearchAllDegreesQuery request,
            CancellationToken cancellationToken)
        {
            return await _searcher.SearchAll();
        }
    }
}
