using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class AmmunitionUpdater
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionUpdater(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Domain.Ammunition ammunition, string type, string mark, string caliber, string series,
            string lot, int quantityAvailable)
        {
            ammunition.Update(type, mark, caliber, series, lot, quantityAvailable);
            await _repository.Update(ammunition);
        }
    }
}
