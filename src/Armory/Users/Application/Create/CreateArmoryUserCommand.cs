using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.Create
{
    public class CreateArmoryUserCommand : Command
    {
        public string UserName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Password { get; }

        public CreateArmoryUserCommand(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}
