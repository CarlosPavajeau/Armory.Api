using System.Threading.Tasks;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Domain;

namespace Armory.Armament.Ammunition.Application.Decrement
{
    public class AmmunitionDecrementer
    {
        private readonly AmmunitionFinder _finder;
        private readonly IAmmunitionRepository _repository;

        public AmmunitionDecrementer(AmmunitionFinder finder, IAmmunitionRepository repository)
        {
            _finder = finder;
            _repository = repository;
        }

        public async Task Decrement(string ammunitionCode, int quantity)
        {
            var ammunition = await _finder.Find(ammunitionCode);
            if (ammunition == null)
            {
                throw new AmmunitionNotFound();
            }

            ammunition.QuantityAvailable -= quantity;
            await _repository.Update(ammunition);
        }
    }
}
