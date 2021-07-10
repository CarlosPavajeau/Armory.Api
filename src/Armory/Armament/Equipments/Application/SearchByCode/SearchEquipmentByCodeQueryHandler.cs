using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.SearchByCode
{
    public class SearchEquipmentByCodeQueryHandler : IQueryHandler<SearchEquipmentByCodeQuery, EquipmentResponse>
    {
        private readonly EquipmentByCodeSearcher _searcher;

        public SearchEquipmentByCodeQueryHandler(EquipmentByCodeSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<EquipmentResponse> Handle(SearchEquipmentByCodeQuery query)
        {
            return await _searcher.Search(query.Code);
        }
    }
}
