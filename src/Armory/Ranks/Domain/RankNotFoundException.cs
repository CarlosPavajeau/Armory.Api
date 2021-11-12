using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Ranks.Domain
{
    /// <summary>
    ///     Represents errors that occur when rank is not found
    /// </summary>
    [Serializable]
    public class RankNotFoundException : ArmoryException
    {
        public RankNotFoundException()
        {
        }

        protected RankNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
