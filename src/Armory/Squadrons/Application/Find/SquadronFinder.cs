using System.Threading.Tasks;
using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application.Find
{
    public class SquadronFinder
    {
        private readonly ISquadronsRepository _repository;

        public SquadronFinder(ISquadronsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Squadron> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
