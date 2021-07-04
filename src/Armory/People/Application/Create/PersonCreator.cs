using System.Threading.Tasks;
using Armory.People.Domain;
using Armory.Users.Application.Create;

namespace Armory.People.Application.Create
{
    public class PersonCreator
    {
        private readonly IPersonRepository _repository;
        private readonly ArmoryUserCreator _userCreator;

        public PersonCreator(IPersonRepository repository, ArmoryUserCreator userCreator)
        {
            _repository = repository;
            _userCreator = userCreator;
        }

        public async Task Create(string id, string firstName, string secondName, string lastName, string secondLastName,
            string email, string phoneNumber, string roleName)
        {
            var user = await _userCreator.Create(id, email, phoneNumber, $"{id}{firstName}", roleName);
            var person = Person.Create(id, firstName, secondName, lastName, secondLastName, user.Id);

            await _repository.Save(person);
        }
    }
}
