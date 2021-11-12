using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Flights.Domain
{
    /// <summary>
    ///     Represents error that occur when a flight is not found.
    /// </summary>
    [Serializable]
    public class FlightNotFoundException : ArmoryException
    {
        public FlightNotFoundException()
        {
        }

        protected FlightNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
