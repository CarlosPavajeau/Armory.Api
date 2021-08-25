using System.Collections.Generic;
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

        public async Task<IEnumerable<Troop>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
