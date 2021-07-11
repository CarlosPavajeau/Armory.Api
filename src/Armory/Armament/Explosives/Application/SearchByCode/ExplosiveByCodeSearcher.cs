using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.SearchByCode
{
    public class ExplosiveByCodeSearcher
    {
        private readonly IExplosivesRepository _repository;

        public ExplosiveByCodeSearcher(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExplosiveResponse> Search(string code)
        {
            var explosive = await _repository.Find(code);
            return explosive == null ? null : ExplosiveResponse.FromAggregate(explosive);
        }
    }
}
