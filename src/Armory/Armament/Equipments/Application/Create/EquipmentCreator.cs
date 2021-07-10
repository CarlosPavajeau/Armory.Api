using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.Create
{
    public class EquipmentCreator
    {
        private readonly IEquipmentsRepository _repository;

        public EquipmentCreator(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string type, string model, string series, int quantityAvailable)
        {
            var equipment = Equipment.Create(code, type, model, series, quantityAvailable);
            await _repository.Save(equipment);
        }
    }
}
