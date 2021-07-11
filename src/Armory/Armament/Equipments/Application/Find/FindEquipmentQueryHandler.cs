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

        public async Task<EquipmentResponse> Handle(FindEquipmentQuery query)
        {
            var equipment = await _searcher.Find(query.Code);
            return equipment == null ? null : EquipmentResponse.FromAggregate(equipment);
        }
    }
}
