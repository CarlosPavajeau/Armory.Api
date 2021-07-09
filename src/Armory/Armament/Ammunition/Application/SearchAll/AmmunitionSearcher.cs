using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.SearchAll
{
    public class AmmunitionSearcher
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionSearcher(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AmmunitionResponse>> SearchAll()
        {
            var ammunition = await _repository.SearchAll();
            return ammunition.Select(AmmunitionResponse.FromAggregate);
        }
    }
}
