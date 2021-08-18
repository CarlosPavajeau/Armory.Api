using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.SearchAllBySquadron
{
    public class SquadsBySquadronSearcher
    {
        private readonly ISquadsRepository _repository;

        public SquadsBySquadronSearcher(ISquadsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SquadResponse>> SearchAllBySquadron(string squadronCode)
        {
            var squads = await _repository.SearchAllBySquadron(squadronCode);
            return squads.Select(SquadResponse.FromAggregate);
        }
    }
}
