using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.CheckExists
{
    public class CheckArmoryUserExistsQuery : Query<bool>
    {
        public CheckArmoryUserExistsQuery(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Email { get; }
        public string PhoneNumber { get; }
    }
}
