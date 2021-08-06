using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.GeneratePasswordResetToken
{
    public class GeneratePasswordResetTokenQuery : Query<PasswordResetTokenResponse>
    {
        public GeneratePasswordResetTokenQuery(string usernameOrEmail)
        {
            UsernameOrEmail = usernameOrEmail;
        }

        public string UsernameOrEmail { get; }
    }
}
