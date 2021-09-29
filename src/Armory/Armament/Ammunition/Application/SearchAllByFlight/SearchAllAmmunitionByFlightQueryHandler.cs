using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Ammunition.Application.SearchAllByFlight
{
    public class
        SearchAllAmmunitionByFlightQueryHandler : IQueryHandler<SearchAllAmmunitionByFlightQuery,
            IEnumerable<AmmunitionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AmmunitionByFlightSearcher _searcher;

        public SearchAllAmmunitionByFlightQueryHandler(AmmunitionByFlightSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AmmunitionResponse>> Handle(SearchAllAmmunitionByFlightQuery request,
            CancellationToken cancellationToken)
        {
            var ammunition = await _searcher.SearchAllByFlight(request.FlightCode);

            return _mapper.Map<IEnumerable<AmmunitionResponse>>(ammunition);
        }
    }
}
