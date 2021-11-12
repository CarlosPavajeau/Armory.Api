using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    /// <summary>
    ///     Represents errors that occur when assigned weapon magazine format is not found
    /// </summary>
    [Serializable]
    public class AssignedWeaponMagazineFormatNotFoundException : ArmoryException
    {
        public AssignedWeaponMagazineFormatNotFoundException()
        {
        }

        public AssignedWeaponMagazineFormatNotFoundException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }
    }
}
