using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.CheckExists
{
    public class AmmunitionExistsChecker
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionExistsChecker(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string code)
        {
            return await _repository.Any(a => a.Code == code);
        }
    }
}
