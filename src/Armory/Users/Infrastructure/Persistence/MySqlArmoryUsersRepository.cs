using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Armory.Users.Infrastructure.Persistence
{
    public class MySqlArmoryUsersRepository : IArmoryUsersRepository
    {
        private readonly ArmoryDbContext _dbContext;
        private readonly SignInManager<ArmoryUser> _signInManager;
        private readonly UserManager<ArmoryUser> _userManager;

        public MySqlArmoryUsersRepository(UserManager<ArmoryUser> userManager, SignInManager<ArmoryUser> signInManager,
            ArmoryDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
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

        public async Task<IEnumerable<ArmoryRole>> SearchAllRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<IdentityResult> AddToRole(ArmoryUser user, string roleName)
        {
            return await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
