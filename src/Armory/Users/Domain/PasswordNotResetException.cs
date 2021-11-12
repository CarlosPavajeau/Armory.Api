using System.Collections.Generic;
using System.Runtime.Serialization;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when password is not reset
    /// </summary>
    public class PasswordNotResetException : ArmoryException
    {
        public PasswordNotResetException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        protected PasswordNotResetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
