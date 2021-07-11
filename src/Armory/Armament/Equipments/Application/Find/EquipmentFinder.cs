using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.Find
{
    public class EquipmentFinder
    {
        private readonly IEquipmentsRepository _repository;

        public EquipmentFinder(IEquipmentsRepository repository)
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
