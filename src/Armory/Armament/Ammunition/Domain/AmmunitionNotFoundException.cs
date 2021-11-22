using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Armament.Ammunition.Domain
{
    /// <summary>
    ///     Represents errors that occur when ammunition is not found
    /// </summary>
    [Serializable]
    public class AmmunitionNotFoundException : ArmoryException
    {
        public AmmunitionNotFoundException()
        {
        }

        public AmmunitionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
