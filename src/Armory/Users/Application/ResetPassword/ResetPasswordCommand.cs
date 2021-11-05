using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ResetPassword
{
    public class ResetPasswordCommand : Command
    {
        public ResetPasswordCommand(string email, string token, string newPassword)
        {
            Email = email;
            Token = token;
            NewPassword = newPassword;
        }

        public string Email { get; }
        public string Token { get; }
        public string NewPassword { get; }
    }
}
