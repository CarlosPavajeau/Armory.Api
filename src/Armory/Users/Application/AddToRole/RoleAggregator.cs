using System.Threading.Tasks;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Application.AddToRole
{
    public class RoleAggregator
    {
        private readonly IArmoryUsersRepository _repository;

        public RoleAggregator(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IdentityResult> AddToRole(ArmoryUser user, string roleName)
        {
            return await _repository.AddToRole(user, roleName);
        }
    }
}
