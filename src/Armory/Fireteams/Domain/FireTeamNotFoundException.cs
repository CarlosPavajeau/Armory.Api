using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Fireteams.Domain
{
    /// <summary>
    ///     Represents error that occur when a fire team is not found.
    /// </summary>
    [Serializable]
    public class FireTeamNotFoundException : ArmoryException
    {
        public FireTeamNotFoundException()
        {
        }

        protected FireTeamNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
