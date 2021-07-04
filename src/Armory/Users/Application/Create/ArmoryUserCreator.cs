using System.Threading.Tasks;
using Armory.Users.Application.AddToRole;
using Armory.Users.Domain;

namespace Armory.Users.Application.Create
{
    public class ArmoryUserCreator
    {
        private readonly IArmoryUserRepository _repository;
        private readonly RoleAggregator _roleAggregator;

        public ArmoryUserCreator(IArmoryUserRepository repository, RoleAggregator roleAggregator)
        {
            _repository = repository;
            _roleAggregator = roleAggregator;
        }

        public async Task<ArmoryUser> Create(string username, string email, string phoneNumber, string password,
            string roleName)
        {
            var user = ArmoryUser.Create(username, email, phoneNumber);

            var result = await _repository.Save(user, password);
            if (!result.Succeeded)
            {
                throw new ArmoryUserNotCreated(result.Errors);
            }

            var roleResult = await _roleAggregator.AddToRole(user, roleName);
            if (!roleResult.Succeeded)
            {
                throw new ArmoryUserNotCreated(roleResult.Errors);
            }

            return user;
        }
    }
}
