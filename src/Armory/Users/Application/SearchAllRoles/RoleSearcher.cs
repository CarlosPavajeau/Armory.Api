using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.SearchAllRoles
{
    public class RoleSearcher
    {
        private readonly IArmoryUsersRepository _repository;

        public RoleSearcher(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ArmoryRoleResponse>> SearchAllRoles()
        {
            var roles = await _repository.SearchAllRoles();
            return roles.Select(ArmoryRoleResponse.FromAggregate);
        }
    }
}
