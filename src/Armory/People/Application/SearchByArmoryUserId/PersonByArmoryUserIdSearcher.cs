using System.Threading.Tasks;
using Armory.People.Domain;

namespace Armory.People.Application.SearchByArmoryUserId
{
    public class PersonByArmoryUserIdSearcher
    {
        private readonly IPeopleRepository _repository;

        public PersonByArmoryUserIdSearcher(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonResponse> SearchByArmoryUserId(string armoryUserId)
        {
            var person = await _repository.FindByArmoryUserId(armoryUserId);
            return person == null ? null : PersonResponse.FromAggregate(person);
        }
    }
}
