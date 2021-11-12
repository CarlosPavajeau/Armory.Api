using System.Collections.Generic;
using System.Runtime.Serialization;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when armory user is not create
    /// </summary>
    public class ArmoryUserNotCreatedException : ArmoryException
    {
        public ArmoryUserNotCreatedException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        protected ArmoryUserNotCreatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
