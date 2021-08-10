using System.Threading.Tasks;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.Decrement
{
    public class EquipmentDecrementer
    {
        private readonly EquipmentFinder _finder;
        private readonly IEquipmentsRepository _repository;

        public EquipmentDecrementer(EquipmentFinder finder, IEquipmentsRepository repository)
        {
            _finder = finder;
            _repository = repository;
        }

        public async Task Decrement(string equipmentCode, int quantity)
        {
            var equipment = await _finder.Find(equipmentCode);
            if (equipment == null)
            {
                throw new EquipmentNotFound();
            }

            equipment.QuantityAvailable -= quantity;
            await _repository.Update(equipment);
        }
    }
}
