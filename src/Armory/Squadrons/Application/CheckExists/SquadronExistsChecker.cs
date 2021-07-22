using System.Threading.Tasks;
using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application.CheckExists
{
    public class SquadronExistsChecker
    {
        private readonly ISquadronsRepository _repository;

        public SquadronExistsChecker(ISquadronsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string code)
        {
            return await _repository.Any(s => s.Code == code);
        }
    }
}
