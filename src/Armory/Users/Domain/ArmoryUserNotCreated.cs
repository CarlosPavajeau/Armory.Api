using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class ArmoryUserNotCreated : Exception
    {
        public ArmoryUserNotCreated(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
