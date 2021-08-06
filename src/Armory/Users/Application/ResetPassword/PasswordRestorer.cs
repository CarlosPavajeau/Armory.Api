using System.Threading.Tasks;
using Armory.Shared.Domain;
using Armory.Users.Domain;

namespace Armory.Users.Application.ResetPassword
{
    public class PasswordRestorer
    {
        private readonly IArmoryUsersRepository _repository;

        public PasswordRestorer(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task ResetPassword(string usernameOrEmail, string token, string newPassword)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null) throw new ArmoryUserNotFound();

            var result = await _repository.ResetPassword(user, Utils.Base64ToString(token), newPassword);
            if (!result.Succeeded) throw new PasswordNotReset(result.Errors);
        }
    }
}
