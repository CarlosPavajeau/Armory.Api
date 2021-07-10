using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.SearchByCode
{
    public class EquipmentByCodeSearcher
    {
        private readonly IEquipmentsRepository _repository;

        public EquipmentByCodeSearcher(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<EquipmentResponse> Search(string code)
        {
            var equipment = await _repository.Find(code);
            return equipment == null ? null : EquipmentResponse.FromAggregate(equipment);
        }
    }
}
