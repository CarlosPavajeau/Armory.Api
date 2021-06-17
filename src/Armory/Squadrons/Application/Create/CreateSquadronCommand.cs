using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squadrons.Application.Create
{
    public class CreateSquadronCommand : Command
    {
        public string Code { get; }
        public string Name { get; }
        public string ArmoryUserId { get; }

        public CreateSquadronCommand(string code, string name, string armoryUserId)
        {
            Code = code;
            Name = name;
            ArmoryUserId = armoryUserId;
        }
    }
}
