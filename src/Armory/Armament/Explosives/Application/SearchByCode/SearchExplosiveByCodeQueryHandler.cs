using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.SearchByCode
{
    public class SearchExplosiveByCodeQueryHandler : IQueryHandler<SearchExplosiveByCodeQuery, ExplosiveResponse>
    {
        private readonly ExplosiveByCodeSearcher _searcher;

        public SearchExplosiveByCodeQueryHandler(ExplosiveByCodeSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<ExplosiveResponse> Handle(SearchExplosiveByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
