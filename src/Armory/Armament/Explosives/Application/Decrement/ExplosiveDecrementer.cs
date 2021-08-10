using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Explosives.Application.Find;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.Decrement
{
    public class ExplosiveDecrementer
    {
        private readonly ExplosiveFinder _finder;
        private readonly IExplosivesRepository _repository;

        public ExplosiveDecrementer(ExplosiveFinder finder, IExplosivesRepository repository)
        {
            _finder = finder;
            _repository = repository;
        }

        public async Task Decrement(string explosiveCode, int quantity)
        {
            var explosive = await _finder.Find(explosiveCode);
            if (explosive == null)
            {
                throw new EquipmentNotFound();
            }

            explosive.QuantityAvailable -= quantity;
            await _repository.Update(explosive);
        }
    }
}
