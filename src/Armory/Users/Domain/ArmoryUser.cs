using Armory.People.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public sealed class ArmoryUser : IdentityUser
    {
        public Person Person { get; set; }

        public ArmoryUser(string username, string email, string phoneNumber)
        {
            UserName = username;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        private ArmoryUser()
        {
        }

        public static ArmoryUser Create(string username, string email, string phoneNumber)
        {
            var user = new ArmoryUser(username, email, phoneNumber);

            return user;
        }
    }
}
