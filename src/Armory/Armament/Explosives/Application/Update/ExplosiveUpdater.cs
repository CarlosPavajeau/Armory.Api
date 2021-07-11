using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.Update
{
    public class ExplosiveUpdater
    {
        private readonly IExplosivesRepository _repository;

        public ExplosiveUpdater(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Explosive explosive, string type, string caliber, string mark, string lot,
            string series, int quantityAvailable)
        {
            explosive.Update(type, caliber, mark, lot, series, quantityAvailable);
            await _repository.Update(explosive);
        }
    }
}
