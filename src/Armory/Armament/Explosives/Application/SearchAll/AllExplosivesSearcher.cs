using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.SearchAll
{
    public class AllExplosivesSearcher
    {
        private readonly IExplosivesRepository _repository;

        public AllExplosivesSearcher(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExplosiveResponse>> SearchAll()
        {
            var explosives = await _repository.SearchAll();
            return explosives.Select(ExplosiveResponse.FromAggregate);
        }
    }
}
