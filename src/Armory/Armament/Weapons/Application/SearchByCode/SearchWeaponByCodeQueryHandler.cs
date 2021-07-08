using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.SearchByCode
{
    public class SearchWeaponByCodeQueryHandler : IQueryHandler<SearchWeaponByCodeQuery, WeaponResponse>
    {
        private readonly WeaponByCodeSearcher _searcher;

        public SearchWeaponByCodeQueryHandler(WeaponByCodeSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<WeaponResponse> Handle(SearchWeaponByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
