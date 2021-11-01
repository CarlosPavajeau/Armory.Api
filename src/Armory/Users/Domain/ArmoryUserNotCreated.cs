using System.Collections.Generic;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when armory user is not create
    /// </summary>
    public class ArmoryUserNotCreated : ArmoryException
    {
        public ArmoryUserNotCreated(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
