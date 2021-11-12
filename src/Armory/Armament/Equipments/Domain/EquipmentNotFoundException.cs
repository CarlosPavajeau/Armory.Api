using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Armament.Equipments.Domain
{
    /// <summary>
    ///     Represents errors that occur when equipment is not found
    /// </summary>
    [Serializable]
    public class EquipmentNotFoundException : ArmoryException
    {
        public EquipmentNotFoundException()
        {
        }

        protected EquipmentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
