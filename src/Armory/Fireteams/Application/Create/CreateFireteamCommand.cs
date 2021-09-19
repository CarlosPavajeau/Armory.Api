using Armory.Shared.Domain.Bus.Command;

namespace Armory.Fireteams.Application.Create
{
    public class CreateFireteamCommand : Command
    {
        public CreateFireteamCommand(string code, string name, string personId, string flightCode)
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
