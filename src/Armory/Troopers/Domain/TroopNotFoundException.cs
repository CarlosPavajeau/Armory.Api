using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Troopers.Domain
{
    /// <summary>
    ///     Represents errors that occur when troop is not found
    /// </summary>
    [Serializable]
    public class TroopNotFoundException : ArmoryException
    {
        public TroopNotFoundException()
        {
        }

        protected TroopNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
