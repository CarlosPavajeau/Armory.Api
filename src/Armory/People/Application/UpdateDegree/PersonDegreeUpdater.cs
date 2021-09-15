using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.UpdateDegree
{
    public class PersonDegreeUpdater
    {
        private readonly IPeopleRepository _repository;

        public PersonDegreeUpdater(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateDegree(Person person, int newDegreeId)
        {
            person.DegreeId = newDegreeId;
            await _repository.Update(person);
        }
    }
}
