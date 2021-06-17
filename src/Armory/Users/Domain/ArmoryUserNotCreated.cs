using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class ArmoryUserNotCreated : Exception
    {
        public IEnumerable<IdentityError> Errors { get; }

        public ArmoryUserNotCreated(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}
