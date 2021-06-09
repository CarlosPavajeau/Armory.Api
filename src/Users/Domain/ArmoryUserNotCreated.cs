using System;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class ArmoryUserNotCreated : Exception
    {
        public IdentityResult Result { get; }

        public ArmoryUserNotCreated(IdentityResult result) : base("User does not created.")
        {
            Result = result;
        }
    }
}
