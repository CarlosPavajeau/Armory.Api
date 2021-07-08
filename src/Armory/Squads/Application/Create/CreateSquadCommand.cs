using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.Application.Create
{
    public class CreateSquadCommand : Command
    {
        public string Code { get; }
        public string Name { get; }
        public string PersonId { get; }
        public string SquadronCode { get; }

        public CreateSquadCommand(string code, string name, string personId, string squadronCode)
        {
            Code = code;
            Name = name;
            PersonId = personId;
            SquadronCode = squadronCode;
        }
    }
}
