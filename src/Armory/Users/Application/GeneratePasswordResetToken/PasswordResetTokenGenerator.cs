using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.GeneratePasswordResetToken
{
    public class PasswordResetTokenGenerator
    {
        private readonly IArmoryUserRepository _repository;

        public PasswordResetTokenGenerator(IArmoryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<PasswordResetTokenResponse> GeneratePasswordResetToken(string usernameOrEmail)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null)
            {
                return new PasswordResetTokenResponse();
            }

            var token = await _repository.GeneratePasswordResetToken(user);
            return new PasswordResetTokenResponse(token);
        }
    }
}
