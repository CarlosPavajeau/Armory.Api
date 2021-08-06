using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class PasswordNotReset : Exception
    {
        public PasswordNotReset(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
