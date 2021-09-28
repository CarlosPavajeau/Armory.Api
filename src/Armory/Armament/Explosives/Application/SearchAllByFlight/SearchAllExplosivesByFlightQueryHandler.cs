using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Explosives.Application.SearchAllByFlight
{
    public class
        SearchAllExplosivesByFlightQueryHandler : IQueryHandler<SearchAllExplosivesByFlightQuery,
            IEnumerable<ExplosiveResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ExplosivesByFlightSearcher _searcher;

        public SearchAllExplosivesByFlightQueryHandler(ExplosivesByFlightSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExplosiveResponse>> Handle(SearchAllExplosivesByFlightQuery request,
            CancellationToken cancellationToken)
        {
            var explosives = await _searcher.SearchAllByFlight(request.FlightCode);

            return _mapper.Map<IEnumerable<ExplosiveResponse>>(explosives);
        }
    }
}
