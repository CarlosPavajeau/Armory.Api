using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.CheckExists
{
    public class SquadExistsChecker
    {
        private readonly ISquadRepository _repository;

        public SquadExistsChecker(ISquadRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string code)
        {
            return await _repository.Any(s => s.Code == code);
        }
    }
}
