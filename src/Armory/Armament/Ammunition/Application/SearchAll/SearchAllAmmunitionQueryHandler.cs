using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.SearchAll
{
    public class
        SearchAllAmmunitionQueryHandler : IQueryHandler<SearchAllAmmunitionQuery, IEnumerable<AmmunitionResponse>>
    {
        private readonly AmmunitionSearcher _searcher;

        public SearchAllAmmunitionQueryHandler(AmmunitionSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<AmmunitionResponse>> Handle(SearchAllAmmunitionQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
