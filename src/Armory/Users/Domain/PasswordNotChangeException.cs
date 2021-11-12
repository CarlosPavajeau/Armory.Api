using System.Collections.Generic;
using System.Runtime.Serialization;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when password is not change
    /// </summary>
    public class PasswordNotChangeException : ArmoryException
    {
        public PasswordNotChangeException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        protected PasswordNotChangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
