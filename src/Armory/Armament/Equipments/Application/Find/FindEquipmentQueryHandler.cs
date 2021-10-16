using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Equipments.Application.Find
{
    public class FindEquipmentQueryHandler : IQueryHandler<FindEquipmentQuery, EquipmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly EquipmentFinder _searcher;

        public FindEquipmentQueryHandler(EquipmentFinder searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<EquipmentResponse> Handle(FindEquipmentQuery request, CancellationToken cancellationToken)
        {
            var equipment = await _searcher.Find(request.Serial);
            return equipment == null ? null : _mapper.Map<EquipmentResponse>(equipment);
        }
    }
}
