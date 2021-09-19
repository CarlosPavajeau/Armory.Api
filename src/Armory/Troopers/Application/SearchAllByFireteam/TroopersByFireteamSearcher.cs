using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.SearchAllByFireteam
{
    public class TroopersByFireteamSearcher
    {
        private readonly ITroopersRepository _repository;

        public TroopersByFireteamSearcher(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Troop>> SearchAllByFireteam(string fireteamCode)
        {
            return await _repository.SearchAllByFireteam(fireteamCode);
        }
    }
}
