using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.CheckExists
{
    public class ExplosiveExistsChecker
    {
        private readonly IExplosivesRepository _repository;

        public ExplosiveExistsChecker(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string serial)
        {
            return await _repository.Any(e => e.Serial == serial);
        }
    }
}
