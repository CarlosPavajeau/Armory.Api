using Armory.Squads.Domain;

namespace Armory.Squads.Application
{
    public class SquadResponse
    {
        public SquadResponse(string code, string name, string personId, string squadronCode)
        {
            Code = code;
            Name = name;
            PersonId = personId;
            SquadronCode = squadronCode;
        }

        public string Code { get; }
        public string Name { get; }
        public string PersonId { get; }
        public string SquadronCode { get; }

        public static SquadResponse FromAggregate(Squad squad)
        {
            return new SquadResponse(squad.Code, squad.Name, squad.PersonId, squad.SquadronCode);
        }
    }
}
