using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.Authenticate
{
    public class ArmoryUserAuthenticator
    {
        private readonly IArmoryUsersRepository _repository;

        public ArmoryUserAuthenticator(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task Authenticate(string usernameOrEmail, string password, bool isPersistent)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null)
            {
                throw new ArmoryUserNotFoundException();
            }

            var result = await _repository.Authenticate(user, password, isPersistent);
            if (!result.Succeeded)
            {
                throw new ArmoryUserNotAuthenticate();
            }
        }
    }
}
