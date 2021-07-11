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

        public async Task Update(string code, string type, string caliber, string mark, string lot, string series,
            int quantityAvailable)
        {
            var explosive = await _repository.Find(code);
            if (explosive == null)
            {
                throw new ExplosiveNotFound();
            }

            explosive.Update(type, caliber, mark, lot, series, quantityAvailable);
            await _repository.Update(explosive);
        }
    }
}
