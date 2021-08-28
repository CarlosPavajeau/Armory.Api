using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.SearchAllBySquad
{
    public class TroopersBySquadSearcher
    {
        private readonly ITroopersRepository _repository;

        public TroopersBySquadSearcher(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Troop>> SearchAllBySquad(string squadCode)
        {
            return await _repository.SearchAllBySquad(squadCode);
        }
    }
}
