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

        public async Task<Domain.Ammunition> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
