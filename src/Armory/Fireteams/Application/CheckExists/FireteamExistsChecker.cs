using System.Threading.Tasks;
using Armory.Fireteams.Domain;

namespace Armory.Fireteams.Application.CheckExists
{
    public class FireteamExistsChecker
    {
        private readonly IFireteamsRepository _repository;

        public FireteamExistsChecker(IFireteamsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string code)
        {
            return await _repository.Any(s => s.Code == code);
        }
    }
}
