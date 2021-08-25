using System.Collections.Generic;
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

        public async Task<IEnumerable<Explosive>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
