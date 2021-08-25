using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Weapons.Application.SearchAll
{
    public class SearchAllWeaponsQueryHandler : IQueryHandler<SearchAllWeaponsQuery, IEnumerable<WeaponResponse>>
    {
        private readonly IMapper _mapper;
        private readonly WeaponSearcher _searcher;

        public SearchAllWeaponsQueryHandler(WeaponSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WeaponResponse>> Handle(SearchAllWeaponsQuery request,
            CancellationToken cancellationToken)
        {
            var weapons = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<WeaponResponse>>(weapons);
        }
    }
}
