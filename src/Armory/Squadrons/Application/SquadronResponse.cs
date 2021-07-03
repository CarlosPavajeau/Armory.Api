using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application
{
    public class SquadronResponse
    {
        public string Code { get; }
        public string Name { get; }
        public string PersonId { get; }

        public SquadronResponse(string code, string name, string personId)
        {
            Code = code;
            Name = name;
            PersonId = personId;
        }

        public static SquadronResponse FromAggregate(Squadron squadron)
        {
            return new(squadron.Code, squadron.Name, squadron.PersonId);
        }
    }
}
