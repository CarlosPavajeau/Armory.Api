using System.Collections.Generic;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when password is not reset
    /// </summary>
    public class PasswordNotReset : ArmoryException
    {
        public PasswordNotReset(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
