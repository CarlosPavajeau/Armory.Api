using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.CheckExists
{
    public class SquadExistsChecker
    {
        private readonly ISquadsRepository _repository;

        public SquadExistsChecker(ISquadsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string code)
        {
            return await _repository.Any(s => s.Code == code);
        }
    }
}
