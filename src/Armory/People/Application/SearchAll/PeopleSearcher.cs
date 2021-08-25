using System.Collections.Generic;
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

        public async Task<IEnumerable<Person>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
