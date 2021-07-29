using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.Find
{
    public class FindEquipmentQueryHandler : IQueryHandler<FindEquipmentQuery, EquipmentResponse>
    {
        private readonly EquipmentFinder _searcher;

        public FindEquipmentQueryHandler(EquipmentFinder searcher)
        {
            _searcher = searcher;
        }

        public async Task<EquipmentResponse> Handle(FindEquipmentQuery request, CancellationToken cancellationToken)
        {
            var equipment = await _searcher.Find(request.Code);
            return equipment == null ? null : EquipmentResponse.FromAggregate(equipment);
        }
    }
}
