using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.Find
{
    public class AmmunitionFinder
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionFinder(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Ammunition> Find(string code, bool noTracking)
        {
            return await _repository.Find(code, noTracking);
        }

        public async Task<Domain.Ammunition> Find(string code)
        {
            return await Find(code, true).ConfigureAwait(false);
        }
    }
}
