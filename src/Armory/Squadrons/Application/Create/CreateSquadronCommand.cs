using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squadrons.Application.Create
{
    public class CreateSquadronCommand : Command
    {
        public CreateSquadronCommand(string code, string name, string personId)
        {
            Code = code;
            Name = name;
            PersonId = personId;
        }

        public string Code { get; }
        public string Name { get; }
        public string PersonId { get; }
    }
}
