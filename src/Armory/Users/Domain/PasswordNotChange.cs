using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class PasswordNotChange : Exception
    {
        public IEnumerable<IdentityError> Errors { get; }

        public PasswordNotChange(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}
