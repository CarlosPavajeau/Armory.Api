using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.Find
{
    public class SearchEquipmentByCodeQueryHandler : IQueryHandler<SearchEquipmentByCodeQuery, EquipmentResponse>
    {
        private readonly EquipmentFinder _searcher;

        public SearchEquipmentByCodeQueryHandler(EquipmentFinder searcher)
        {
            _searcher = searcher;
        }

        public async Task<EquipmentResponse> Handle(SearchEquipmentByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
