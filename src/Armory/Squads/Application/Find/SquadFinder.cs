using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.Find
{
    public class SquadFinder
    {
        private readonly ISquadRepository _repository;

        public SquadFinder(ISquadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Squad> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
