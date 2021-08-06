using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ResetPassword
{
    public class ResetPasswordCommand : Command
    {
        public ResetPasswordCommand(string usernameOrEmail, string token, string newPassword)
        {
            UsernameOrEmail = usernameOrEmail;
            Token = token;
            NewPassword = newPassword;
        }

        public string UsernameOrEmail { get; }
        public string Token { get; }
        public string NewPassword { get; }
    }
}
