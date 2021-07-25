using System;
using System.Threading.Tasks;
using Armory.Users.Application.AddToRole;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Application.Create
{
    public class ArmoryUserCreator
    {
        private readonly IArmoryUsersRepository _repository;
        private readonly RoleAggregator _roleAggregator;

        public ArmoryUserCreator(IArmoryUsersRepository repository, RoleAggregator roleAggregator)
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

            try
            {
                var roleResult = await _roleAggregator.AddToRole(user, roleName);
                if (!roleResult.Succeeded)
                {
                    throw new ArmoryUserNotCreated(roleResult.Errors);
                }
            }
            catch (InvalidOperationException e)
            {
                throw new ArmoryUserNotCreated(new[]
                {
                    new IdentityError
                    {
                        Code = "RoleDoesNotExists",
                        Description = $"El rol '{roleName}' no existe."
                    }
                });
            }


            return user;
        }
    }
}
