using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Squadron.Domain;

namespace Armory.Squadron.Application.SearchAll
{
    public class SquadronsSearcher
    {
        private readonly ISquadronRepository _repository;

        public SquadronsSearcher(ISquadronRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SquadronResponse>> SearchAll()
        {
            var squadrons = await _repository.GetAll();
            return squadrons.Select(SquadronResponse.FromAggregate);
        }
    }
}
