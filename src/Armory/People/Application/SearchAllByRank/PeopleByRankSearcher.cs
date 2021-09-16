using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.SearchAllByRank
{
    public class PeopleByRankSearcher
    {
        private readonly IPeopleRepository _repository;

        public PeopleByRankSearcher(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> SearchAllByRank(string rankName)
        {
            return await _repository.SearchAllByRank(rankName);
        }
    }
}
