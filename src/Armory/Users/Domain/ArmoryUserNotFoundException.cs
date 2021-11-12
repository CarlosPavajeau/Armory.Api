using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when armory user is not found
    /// </summary>
    public class ArmoryUserNotFoundException : ArmoryException
    {
        public ArmoryUserNotFoundException() : base("User not found.")
        {
        }

        protected ArmoryUserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
