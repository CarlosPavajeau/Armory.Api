using System.Collections.Generic;
using System.Runtime.Serialization;
using Armory.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when email is not confirmed
    /// </summary>
    public class EmailNotConfirmedException : ArmoryException
    {
        public EmailNotConfirmedException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }

        protected EmailNotConfirmedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
