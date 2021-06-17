using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.Create
{
    public class ArmoryUserCreator
    {
        private readonly IArmoryUserRepository _repository;

        public ArmoryUserCreator(IArmoryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string username, string email, string phone, string password)
        {
            var user = ArmoryUser.Create(username, email, phone);

            var result = await _repository.Save(user, password);
            if (!result.Succeeded)
            {
                throw new ArmoryUserNotCreated(result.Errors);
            }
        }
    }
}
