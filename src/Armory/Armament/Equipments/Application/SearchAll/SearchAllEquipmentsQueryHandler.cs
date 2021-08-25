using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Equipments.Application.SearchAll
{
    public class
        SearchAllEquipmentsQueryHandler : IQueryHandler<SearchAllEquipmentsQuery, IEnumerable<EquipmentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AllEquipmentsSearcher _searcher;

        public SearchAllEquipmentsQueryHandler(AllEquipmentsSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentResponse>> Handle(SearchAllEquipmentsQuery request,
            CancellationToken cancellationToken)
        {
            var equipments = await _searcher.SearchAll();
            return _mapper.Map<IEnumerable<EquipmentResponse>>(equipments);
        }
    }
}
