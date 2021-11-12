using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Squads.Domain
{
    /// <summary>
    ///     Represents errors that occur when squad is not found
    /// </summary>
    [Serializable]
    public class SquadNotFoundException : ArmoryException
    {
        /// <summary>
        ///     Initializes a new instance of the SquadNotFoundException class.
        /// </summary>
        public SquadNotFoundException()
        {
        }

        protected SquadNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
