namespace Armory.Squadron.Application
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

        public static SquadronResponse FromAggregate(Domain.Squadron squadron)
        {
            return new SquadronResponse(squadron.Code, squadron.Name, squadron.ArmoryUserId);
        }
    }
}
