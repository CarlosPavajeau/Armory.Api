using System.Collections.Generic;
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

        public async Task<IEnumerable<Squad>> SearchAllBySquadron(string squadronCode)
        {
            return await _repository.SearchAllBySquadron(squadronCode);
        }
    }
}
