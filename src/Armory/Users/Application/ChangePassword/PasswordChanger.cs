using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.ChangePassword
{
    public class PasswordChanger
    {
        private readonly IArmoryUsersRepository _repository;

        public PasswordChanger(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task ChangePassword(string usernameOrEmail, string oldPassword, string newPassword)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null) throw new ArmoryUserNotFound();

            var result = await _repository.ChangePassword(user, oldPassword, newPassword);
            if (!result.Succeeded) throw new PasswordNotChange(result.Errors);
        }
    }
}
