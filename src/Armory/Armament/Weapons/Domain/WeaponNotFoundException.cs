using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Armament.Weapons.Domain
{
    /// <summary>
    ///     Represents errors that occur when weapon is not found
    /// </summary>
    [Serializable]
    public class WeaponNotFoundException : ArmoryException
    {
        public WeaponNotFoundException()
        {
        }

        protected WeaponNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
