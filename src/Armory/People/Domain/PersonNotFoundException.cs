using System;
using System.Runtime.Serialization;
using Armory.Shared.Domain;

namespace Armory.People.Domain
{
    /// <summary>
    ///     Represents errors that occur when person is not found
    /// </summary>
    [Serializable]
    public class PersonNotFoundException : ArmoryException
    {
        public PersonNotFoundException()
        {
        }

        protected PersonNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
