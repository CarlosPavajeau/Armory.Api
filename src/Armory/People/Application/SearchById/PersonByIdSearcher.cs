using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.SearchById
{
    public class PersonByIdSearcher
    {
        private readonly IPersonRepository _personRepository;

        public PersonByIdSearcher(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonResponse> SearchById(string id)
        {
            var person = await _personRepository.Find(id);
            return person == null ? null : PersonResponse.FromAggregate(person);
        }
    }
}
