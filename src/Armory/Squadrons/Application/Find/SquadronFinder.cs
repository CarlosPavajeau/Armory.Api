using System.Threading.Tasks;
using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application.Find
{
    public class SquadronFinder
    {
        private readonly ISquadronRepository _repository;

        public SquadronFinder(ISquadronRepository repository)
        {
            _repository = repository;
        }

        public async Task<Squadron> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
