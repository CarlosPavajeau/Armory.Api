using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Equipments.Application.SearchAll
{
    public class
        SearchAllEquipmentsQueryHandler : IQueryHandler<SearchAllEquipmentsQuery, IEnumerable<EquipmentResponse>>
    {
        private readonly AllEquipmentsSearcher _searcher;

        public SearchAllEquipmentsQueryHandler(AllEquipmentsSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<IEnumerable<EquipmentResponse>> Handle(SearchAllEquipmentsQuery query)
        {
            return await _searcher.SearchAll();
        }
    }
}
