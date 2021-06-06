using System;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class ArmoryUserNotCreate : Exception
    {
        public IdentityResult Result { get; }

        public ArmoryUserNotCreate(IdentityResult result) : base("User does not created.")
        {
            Result = result;
        }
    }
}
