using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when armory user is not authenticate
    /// </summary>
    [Serializable]
    public class ArmoryUserNotAuthenticate : ArmoryException
    {
        public ArmoryUserNotAuthenticate()
        {
        }

        protected ArmoryUserNotAuthenticate(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
