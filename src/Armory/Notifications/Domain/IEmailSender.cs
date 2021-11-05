using System.Threading.Tasks;

namespace Armory.Notifications.Domain
{
    /// <summary>
    ///     Interface for sending notifications via email
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        ///     Send an email to reset the password
        /// </summary>
        /// <param name="email">Email to send</param>
        /// <param name="callbackUrl">Callback url</param>
        /// <returns></returns>
        Task SendResetPasswordEmail(string email, string callbackUrl);
    }
}
