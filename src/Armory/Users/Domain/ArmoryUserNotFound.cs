using System;

namespace Armory.Users.Domain
{
    public class ArmoryUserNotFound : Exception
    {
        public ArmoryUserNotFound() : base("User not found.")
        {
        }
    }
}
