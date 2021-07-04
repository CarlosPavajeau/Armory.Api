using Armory.Users.Domain;

namespace Armory.Users.Application
{
    public class ArmoryRoleResponse
    {
        public string Name { get; }

        public ArmoryRoleResponse(string name)
        {
            Name = name;
        }

        public static ArmoryRoleResponse FromAggregate(ArmoryRole role)
        {
            return new(role.Name);
        }
    }
}
