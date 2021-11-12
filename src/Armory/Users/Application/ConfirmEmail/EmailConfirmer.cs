using System.Threading.Tasks;
using Armory.Shared.Domain;
using Armory.Users.Domain;

namespace Armory.Users.Application.ConfirmEmail
{
    public class EmailConfirmer
    {
        private readonly IArmoryUsersRepository _repository;

        public EmailConfirmer(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task ConfirmEmail(string usernameOrEmail, string token)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null)
            {
                throw new ArmoryUserNotFoundException();
            }

            var result = await _repository.ConfirmEmail(user, Utils.Base64ToString(token));
            if (!result.Succeeded)
            {
                throw new EmailNotConfirmedException(result.Errors);
            }
        }
    }
}
