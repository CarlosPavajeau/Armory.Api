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

        /// <summary>
        ///     Initializes a new instance of the SquadNotFoundException class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        public SquadNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
