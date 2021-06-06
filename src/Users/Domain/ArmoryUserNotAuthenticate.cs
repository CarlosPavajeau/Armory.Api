using System;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class ArmoryUserNotAuthenticate : Exception
    {
        public SignInResult Result { get; }

        public ArmoryUserNotAuthenticate(SignInResult result)
        {
            Result = result;
        }

        public ArmoryUserNotAuthenticate() : base("User not found.")
        {
        }
    }
}
