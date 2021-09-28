using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Weapons.Application.SearchAllByFlight
{
    public class
        SearchAllWeaponsByFlightQueryHandler : IQueryHandler<SearchAllWeaponsByFlightQuery, IEnumerable<WeaponResponse>>
    {
        private readonly IMapper _mapper;
        private readonly WeaponsByFlightSearcher _searcher;

        public SearchAllWeaponsByFlightQueryHandler(WeaponsByFlightSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WeaponResponse>> Handle(SearchAllWeaponsByFlightQuery request,
            CancellationToken cancellationToken)
        {
            var weapons = await _searcher.SearchAllByFlight(request.FlightCode);

            return _mapper.Map<IEnumerable<WeaponResponse>>(weapons);
        }
    }
}
