using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Equipments.Application.SearchAllByFlight
{
    public class
        SearchAllEquipmentsByFlightQueryHandler : IQueryHandler<SearchAllEquipmentsByFlightQuery,
            IEnumerable<EquipmentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly EquipmentsByFlightSearcher _searcher;

        public SearchAllEquipmentsByFlightQueryHandler(EquipmentsByFlightSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentResponse>> Handle(SearchAllEquipmentsByFlightQuery request,
            CancellationToken cancellationToken)
        {
            var equipments = await _searcher.SearchAllByFlight(request.FlightCode);

            return _mapper.Map<IEnumerable<EquipmentResponse>>(equipments);
        }
    }
}
