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

        public async Task<Equipment> Find(string code, bool noTracking)
        {
            return await _repository.Find(code, noTracking);
        }

        public async Task<Equipment> Find(string code)
        {
            return await Find(code, true).ConfigureAwait(false);
        }
    }
}
