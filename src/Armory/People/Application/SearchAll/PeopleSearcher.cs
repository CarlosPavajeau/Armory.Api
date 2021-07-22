using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.SearchAll
{
    public class PeopleSearcher
    {
        private readonly IPeopleRepository _repository;

        public PeopleSearcher(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonResponse>> SearchAll()
        {
            var people = await _repository.SearchAll();
            return people.Select(PersonResponse.FromAggregate);
        }
    }
}
