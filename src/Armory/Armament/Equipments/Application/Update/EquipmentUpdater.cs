using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.Update
{
    public class EquipmentUpdater
    {
        private readonly IEquipmentsRepository _repository;

        public EquipmentUpdater(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Equipment equipment, string type, string model, string series, int quantityAvailable)
        {
            equipment.Update(type, model, series, quantityAvailable);
            await _repository.Update(equipment);
        }
    }
}
