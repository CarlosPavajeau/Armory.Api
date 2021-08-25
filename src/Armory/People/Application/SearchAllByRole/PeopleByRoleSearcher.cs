using System.Collections.Generic;
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

        public async Task<IEnumerable<Person>> SearchAllByRole(string roleName)
        {
            return await _repository.SearchAllByRole(roleName);
        }
    }
}
