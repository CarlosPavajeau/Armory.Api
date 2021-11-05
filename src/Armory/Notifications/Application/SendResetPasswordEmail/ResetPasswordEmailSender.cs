using System.Threading.Tasks;
using Armory.Notifications.Domain;

namespace Armory.Notifications.Application.SendResetPasswordEmail
{
    public class ResetPasswordEmailSender
    {
        private readonly IEmailSender _sender;

        public ResetPasswordEmailSender(IEmailSender sender)
        {
            _sender = sender;
        }

        public async Task SendResetPasswordEmail(string email, string callbackUrl)
        {
            await _sender.SendResetPasswordEmail(email, callbackUrl);
        }
    }
}
