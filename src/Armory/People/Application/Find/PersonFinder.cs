using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Find
{
    public class PersonFinder
    {
        private readonly IPersonRepository _personRepository;

        public PersonFinder(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Find(string id)
        {
            return await _personRepository.Find(id);
        }
    }
}
