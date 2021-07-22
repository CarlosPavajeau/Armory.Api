using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.SearchAllByRole
{
    public class PeopleByRoleSearcher
    {
        private readonly IPeopleRepository _repository;

        public PeopleByRoleSearcher(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonResponse>> SearchAllByRole(string roleName)
        {
            var people = await _repository.SearchAllByRole(roleName);
            return people.Select(PersonResponse.FromAggregate);
        }
    }
}
