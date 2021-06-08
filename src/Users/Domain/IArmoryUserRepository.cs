using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public interface IArmoryUserRepository
    {
        Task<IdentityResult> Save(ArmoryUser user, string password);
        Task<ArmoryUser> FindByUsernameOrEmail(string usernameOrEmail);
        Task<SignInResult> Authenticate(ArmoryUser user, string password, bool isPersistent);
        Task<string> GeneratePasswordResetToken(ArmoryUser user);
        Task<IdentityResult> ResetPassword(ArmoryUser user, string token, string newPassword);
        Task Logout();
    }
}
