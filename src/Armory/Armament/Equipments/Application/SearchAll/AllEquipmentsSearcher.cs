using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.SearchAll
{
    public class AllEquipmentsSearcher
    {
        private readonly IEquipmentsRepository _repository;

        public AllEquipmentsSearcher(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EquipmentResponse>> SearchAll()
        {
            var equipment = await _repository.SearchAll();
            return equipment.Select(EquipmentResponse.FromAggregate);
        }
    }
}
