using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application
{
    public class SquadronResponse
    {
        public SquadronResponse(string code, string name, string personId)
        {
            Code = code;
            Name = name;
            PersonId = personId;
        }

        public string Code { get; }
        public string Name { get; }
        public string PersonId { get; }

        public static SquadronResponse FromAggregate(Squadron squadron)
        {
            return new SquadronResponse(squadron.Code, squadron.Name, squadron.PersonId);
        }
    }
}
