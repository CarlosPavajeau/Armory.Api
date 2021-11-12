using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.Degrees.Domain
{
    /// <summary>
    ///     Represents error that occur when degree is not found
    /// </summary>
    [Serializable]
    public class DegreeNotFoundException : ArmoryException
    {
        public DegreeNotFoundException()
        {
        }

        protected DegreeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
