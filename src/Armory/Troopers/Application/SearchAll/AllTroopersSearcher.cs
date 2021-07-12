using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.SearchAll
{
    public class AllTroopsSearcher
    {
        private readonly ITroopersRepository _repository;

        public AllTroopsSearcher(ITroopersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TroopResponse>> SearchAll()
        {
            var troopers = await _repository.SearchAll();
            return troopers.Select(TroopResponse.FromAggregate);
        }
    }
}
