using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.Find
{
    public class PersonFinder
    {
        private readonly IPeopleRepository _peopleRepository;

        public PersonFinder(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<Person> Find(string id)
        {
            return await _peopleRepository.Find(id);
        }
    }
}
