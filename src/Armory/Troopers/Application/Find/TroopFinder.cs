using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.Find
{
    public class TroopFinder
    {
        private readonly ITroopersRepository _repository;

        public TroopFinder(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task<Troop> Find(string id, bool noTracking)
        {
            return await _repository.Find(id, noTracking);
        }

        public async Task<Troop> Find(string id)
        {
            return await Find(id, true);
        }
    }
}
