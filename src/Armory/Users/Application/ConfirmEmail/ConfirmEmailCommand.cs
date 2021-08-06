using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ConfirmEmail
{
    public class ConfirmEmailCommand : Command
    {
        public ConfirmEmailCommand(string usernameOrEmail, string token)
        {
            UsernameOrEmail = usernameOrEmail;
            Token = token;
        }

        public string UsernameOrEmail { get; }
        public string Token { get; }
    }
}
