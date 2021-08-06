using Armory.Users.Domain;

namespace Armory.Users.Application
{
    public class ArmoryRoleResponse
    {
        public ArmoryRoleResponse(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static ArmoryRoleResponse FromAggregate(ArmoryRole role)
        {
            return new ArmoryRoleResponse(role.Name);
        }
    }
}
