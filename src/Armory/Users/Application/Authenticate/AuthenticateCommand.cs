using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.Authenticate
{
    public class AuthenticateCommand : Command
    {
        public string UsernameOrEmail { get; }
        public string Password { get; }
        public bool IsPersistent { get; }

        public AuthenticateCommand(string usernameOrEmail, string password, bool isPersistent)
        {
            UsernameOrEmail = usernameOrEmail;
            Password = password;
            IsPersistent = isPersistent;
        }
    }
}
