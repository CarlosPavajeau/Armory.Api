using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application
{
    public class SquadronResponse
    {
        public string Code { get; }
        public string Name { get; }
        public string ArmoryUserId { get; }

        public SquadronResponse(string code, string name, string armoryUserId)
        {
            Code = code;
            Name = name;
            ArmoryUserId = armoryUserId;
        }

        public static SquadronResponse FromAggregate(Squadron squadron)
        {
            return new(squadron.Code, squadron.Name, squadron.ArmoryUserId);
        }
    }
}
