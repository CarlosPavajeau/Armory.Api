using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.Create
{
    public class ArmoryUserCreator
    {
        private readonly IArmoryUsersRepository _repository;

        public ArmoryUserCreator(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArmoryUser> Create(string username, string email, string phoneNumber, string password)
        {
            var user = ArmoryUser.Create(username, email, phoneNumber);

            var result = await _repository.Save(user, password);
            if (!result.Succeeded)
            {
                throw new ArmoryUserNotCreated(result.Errors);
            }

            return user;
        }
    }
}
