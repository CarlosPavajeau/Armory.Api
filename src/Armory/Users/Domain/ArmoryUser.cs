using Armory.People.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public sealed class ArmoryUser : IdentityUser
    {
        public Person Person { get; set; }

        public ArmoryUser(string username, string email, string phone)
        {
            UserName = username;
            Email = email;
            PhoneNumber = phone;
        }

        private ArmoryUser()
        {
        }

        public static ArmoryUser Create(string username, string email, string phone)
        {
            var user = new ArmoryUser(username, email, phone);

            return user;
        }
    }
}
