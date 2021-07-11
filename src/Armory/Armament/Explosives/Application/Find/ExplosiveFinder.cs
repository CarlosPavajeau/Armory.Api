using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.Find
{
    public class ExplosiveFinder
    {
        private readonly IExplosivesRepository _repository;

        public ExplosiveFinder(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Explosive> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
