using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.SearchAll
{
    public class SearchAllWeaponsQueryHandler : IQueryHandler<SearchAllWeaponsQuery, IEnumerable<WeaponResponse>>
    {
        private readonly WeaponSearcher _searcher;

        public SearchAllWeaponsQueryHandler(WeaponSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<WeaponResponse>> Handle(SearchAllWeaponsQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
