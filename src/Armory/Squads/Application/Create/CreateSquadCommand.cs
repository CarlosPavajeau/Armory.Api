using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.Application.Create
{
    public class CreateSquadCommand : Command
    {
        public CreateSquadCommand(string code, string name, string personId, string flightCode)
        {
            Code = code;
            Name = name;
            PersonId = personId;
            FlightCode = flightCode;
        }

        public string Code { get; }
        public string Name { get; }
        public string PersonId { get; }
        public string FlightCode { get; }
    }
}
