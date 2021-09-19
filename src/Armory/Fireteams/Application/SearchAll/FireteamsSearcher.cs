using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Fireteams.Domain;

namespace Armory.Fireteams.Application.SearchAll
{
    public class FireteamsSearcher
    {
        private readonly IFireteamsRepository _repository;

        public FireteamsSearcher(IFireteamsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Fireteam>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
