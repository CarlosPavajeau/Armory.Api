using System.Threading.Tasks;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Persistence.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Infrastructure.Persistence
{
    public class MySqlArmoryUserRepository : IArmoryUserRepository
    {
        private readonly ArmoryUserDbContext _context;
        private readonly UserManager<ArmoryUser> _userManager;

        public MySqlArmoryUserRepository(ArmoryUserDbContext context, UserManager<ArmoryUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Save(ArmoryUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
