using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.GeneratePasswordResetToken
{
    public class GeneratePasswordResetTokenQuery : Query<PasswordResetTokenResponse>
    {
        public string UsernameOrEmail { get; }

        public GeneratePasswordResetTokenQuery(string usernameOrEmail)
        {
            UsernameOrEmail = usernameOrEmail;
        }
    }
}
