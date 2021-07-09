using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.SearchByCode
{
    public class SearchAmmunitionByCodeQueryHandler : IQueryHandler<SearchAmmunitionByCodeQuery, AmmunitionResponse>
    {
        private readonly AmmunitionByCodeSearcher _searcher;

        public SearchAmmunitionByCodeQueryHandler(AmmunitionByCodeSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<AmmunitionResponse> Handle(SearchAmmunitionByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
