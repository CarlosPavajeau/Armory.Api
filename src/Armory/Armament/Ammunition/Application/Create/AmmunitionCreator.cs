using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.Create
{
    public class AmmunitionCreator
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionCreator(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string type, string mark, string caliber, string series, string lot,
            int quantityAvailable)
        {
            var ammunition = Domain.Ammunition.Create(code, type, mark, caliber, series, lot, quantityAvailable);
            await _repository.Save(ammunition);
        }
    }
}
