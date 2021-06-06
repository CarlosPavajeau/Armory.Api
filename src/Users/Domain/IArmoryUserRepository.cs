using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public interface IArmoryUserRepository
    {
        Task<IdentityResult> Save(ArmoryUser user, string password);
    }
}
