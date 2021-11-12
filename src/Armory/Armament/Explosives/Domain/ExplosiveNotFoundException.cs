using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Armament.Explosives.Domain
{
    /// <summary>
    ///     Represents errors that occur when explosive is not found
    /// </summary>
    [Serializable]
    public class ExplosiveNotFoundException : ArmoryException
    {
        public ExplosiveNotFoundException()
        {
        }

        protected ExplosiveNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
