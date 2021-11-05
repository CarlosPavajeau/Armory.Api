using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Armory.Notifications.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Armory.Notifications.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _client;
        private readonly ILogger<EmailSender> _logger;
        private readonly EmailSettings _settings;

        public EmailSender(IOptions<EmailSettings> settings, ILogger<EmailSender> logger)
        {
            _settings = settings.Value;
            _logger = logger;

            _client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSsl
            };
        }

        public async Task SendResetPasswordEmail(string email, string callbackUrl)
        {
            var message = new MailMessage(_settings.Username, email)
            {
                Subject = "Reestrablecer contraseña",
                Body =
                    $"Por favor, restablezca su contraseña haciendo clic <a href='{callbackUrl}' target='blank'>aquí</a>.",
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            await SendEmail(message);
        }

        private async Task SendEmail(MailMessage message)
        {
            try
            {
                await _client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
            }
        }
    }
}
