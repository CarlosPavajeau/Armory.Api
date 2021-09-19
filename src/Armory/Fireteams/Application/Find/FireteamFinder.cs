using System.Threading.Tasks;
using Armory.Fireteams.Domain;

namespace Armory.Fireteams.Application.Find
{
    public class FireteamFinder
    {
        private readonly IFireteamsRepository _repository;

        public FireteamFinder(IFireteamsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Fireteam> Find(string code)
        {
            return await _repository.Find(code);
        }
    }
}
