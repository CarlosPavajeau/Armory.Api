using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ChangePassword
{
    public class ChangePasswordCommand : Command
    {
        public string UsernameOrEmail { get; }
        public string OldPassword { get; }
        public string NewPassword { get; }

        public ChangePasswordCommand(string usernameOrEmail, string oldPassword, string newPassword)
        {
            UsernameOrEmail = usernameOrEmail;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
