using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.GenerateEmailConfirmationToken
{
    public class GenerateEmailConfirmationTokenQuery : Query
    {
        public string UsernameOrEmail { get; }

        public GenerateEmailConfirmationTokenQuery(string usernameOrEmail)
        {
            UsernameOrEmail = usernameOrEmail;
        }
    }
}
