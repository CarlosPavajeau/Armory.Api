using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.CheckExists
{
    public class ArmoryUserExistsChecker
    {
        private readonly IArmoryUsersRepository _repository;

        public ArmoryUserExistsChecker(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(string email, string phoneNumber)
        {
            return await _repository.Any(a => a.Email == email || a.PhoneNumber == phoneNumber);
        }
    }
}
