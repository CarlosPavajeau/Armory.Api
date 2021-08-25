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

        public async Task<Person> SearchByArmoryUserId(string armoryUserId)
        {
            return await _repository.FindByArmoryUserId(armoryUserId);
        }
    }
}
