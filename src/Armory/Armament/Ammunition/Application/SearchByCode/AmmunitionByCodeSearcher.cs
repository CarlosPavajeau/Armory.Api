using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.SearchByCode
{
    public class AmmunitionByCodeSearcher
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionByCodeSearcher(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task<AmmunitionResponse> Search(string code)
        {
            var ammunition = await _repository.Find(code);
            return ammunition == null ? null : AmmunitionResponse.FromAggregate(ammunition);
        }
    }
}
