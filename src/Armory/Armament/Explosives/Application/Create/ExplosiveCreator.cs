using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application.Create
{
    public class ExplosiveCreator
    {
        private readonly IExplosivesRepository _repository;

        public ExplosiveCreator(IExplosivesRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string type, string caliber, string mark, string lot, string series,
            int quantityAvailable)
        {
            var explosive = Explosive.Create(code, type, caliber, mark, lot, series, quantityAvailable);
            await _repository.Save(explosive);
        }
    }
}
