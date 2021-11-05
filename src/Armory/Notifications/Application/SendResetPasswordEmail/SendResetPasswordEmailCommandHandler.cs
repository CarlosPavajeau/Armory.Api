using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain;
using Armory.Shared.Domain.Bus.Command;
using Microsoft.Extensions.Options;

namespace Armory.Notifications.Application.SendResetPasswordEmail
{
    public class SendResetPasswordEmailCommandHandler : CommandHandler<SendResetPasswordEmailCommand>
    {
        private readonly ApplicationProperties _properties;
        private readonly ResetPasswordEmailSender _sender;

        public SendResetPasswordEmailCommandHandler(ResetPasswordEmailSender sender,
            IOptions<ApplicationProperties> properties)
        {
            _sender = sender;
            _properties = properties.Value;
        }

        protected override async Task Handle(SendResetPasswordEmailCommand request, CancellationToken cancellationToken)
        {
            var callbackUrl =
                $"{_properties.FrontendUrl}/reset_password?token={Utils.StringToBase64(request.Token)}&email={request.Email}";
            await _sender.SendResetPasswordEmail(request.Email, callbackUrl);
        }
    }
}
