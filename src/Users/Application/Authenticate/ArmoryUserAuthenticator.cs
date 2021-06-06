using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.Authenticate
{
    public class ArmoryUserAuthenticator
    {
        private readonly IArmoryUserRepository _repository;

        public ArmoryUserAuthenticator(IArmoryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Authenticate(string usernameOrEmail, string password, bool isPersistent)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null)
            {
                throw new ArmoryUserNotAuthenticate();
            }

            var result = await _repository.Authenticate(user, password, isPersistent);
            if (!result.Succeeded)
            {
                throw new ArmoryUserNotAuthenticate(result);
            }
        }
    }
}
