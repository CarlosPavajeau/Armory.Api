using Armory.Shared.Domain.Bus.Command;

namespace Armory.Notifications.Application.SendResetPasswordEmail
{
    public class SendResetPasswordEmailCommand : Command
    {
        public string Email { get; init; }
        public string Token { get; init; }
    }
}
