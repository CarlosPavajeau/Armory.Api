using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.CheckExists
{
    public class EquipmentExistsChecker
    {
        private readonly IEquipmentsRepository _repository;

        public EquipmentExistsChecker(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string series)
        {
            return await _repository.Any(e => e.Series == series);
        }
    }
}
