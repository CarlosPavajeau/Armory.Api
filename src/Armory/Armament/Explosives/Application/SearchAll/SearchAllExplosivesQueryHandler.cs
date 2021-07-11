using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.SearchAll
{
    public class
        SearchAllExplosivesQueryHandler : IQueryHandler<SearchAllExplosivesQuery, IEnumerable<ExplosiveResponse>>
    {
        private readonly AllExplosivesSearcher _searcher;

        public SearchAllExplosivesQueryHandler(AllExplosivesSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<ExplosiveResponse>> Handle(SearchAllExplosivesQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
