using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.CheckExists
{
    public class TroopExistsChecker
    {
        private readonly ITroopersRepository _repository;

        public TroopExistsChecker(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string id)
        {
            return await _repository.Any(p => p.Id == id);
        }
    }
}
