using System.Collections.Generic;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when password is not change
    /// </summary>
    public class PasswordNotChange : ArmoryException
    {
        public PasswordNotChange(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
