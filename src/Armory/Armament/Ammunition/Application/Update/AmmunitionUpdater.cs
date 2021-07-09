using System.Threading.Tasks;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class AmmunitionUpdater
    {
        private readonly IAmmunitionRepository _repository;

        public AmmunitionUpdater(IAmmunitionRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(string code, string type, string mark, string caliber, string series, string lot,
            int quantityAvailable)
        {
            var ammunition = await _repository.Find(code);
            if (ammunition == null)
            {
                throw new AmmunitionNotFound();
            }

            ammunition.Update(type, mark, caliber, series, lot, quantityAvailable);
            await _repository.Update(ammunition);
        }
    }
}
