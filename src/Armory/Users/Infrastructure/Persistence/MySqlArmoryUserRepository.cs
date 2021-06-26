using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Infrastructure.Persistence
{
    public class MySqlArmoryUserRepository : IArmoryUserRepository
    {
        private readonly UserManager<ArmoryUser> _userManager;
        private readonly SignInManager<ArmoryUser> _signInManager;

        public MySqlArmoryUserRepository(UserManager<ArmoryUser> userManager, SignInManager<ArmoryUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Save(ArmoryUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ArmoryUser> FindByUsernameOrEmail(string usernameOrEmail)
        {
            var user = await _userManager.FindByNameAsync(usernameOrEmail) ??
                       await _userManager.FindByEmailAsync(usernameOrEmail);
            return user;
        }

        public async Task<SignInResult> Authenticate(ArmoryUser user, string password, bool isPersistent)
        {
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, false);
        }

        public async Task<string> GeneratePasswordResetToken(ArmoryUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPassword(ArmoryUser user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<IdentityResult> ChangePassword(ArmoryUser user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<string> GenerateEmailConfirmationToken(ArmoryUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmail(ArmoryUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IEnumerable<ArmoryUser>> SearchAllUsersInRole(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }
    }
}
