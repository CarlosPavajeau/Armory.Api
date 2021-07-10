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

        public async Task Update(string code, string type, string model, string series, int quantityAvailable)
        {
            var equipment = await _repository.Find(code);
            if (equipment == null)
            {
                throw new EquipmentNotFound();
            }

            equipment.Update(type, model, series, quantityAvailable);
            await _repository.Update(equipment);
        }
    }
}
