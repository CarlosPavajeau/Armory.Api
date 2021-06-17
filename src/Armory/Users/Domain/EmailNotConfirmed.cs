using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public class EmailNotConfirmed : Exception
    {
        public IEnumerable<IdentityError> Errors { get; }

        public EmailNotConfirmed(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}
