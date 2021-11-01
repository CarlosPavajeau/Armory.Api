using Armory.Shared.Domain;

namespace Armory.Users.Domain
{
    /// <summary>
    ///     Represents errors that occur when armory user is not found
    /// </summary>
    public class ArmoryUserNotFound : ArmoryException
    {
        public ArmoryUserNotFound() : base("User not found.")
        {
        }
    }
}
