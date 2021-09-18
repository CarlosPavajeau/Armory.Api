using Armory.Shared.Domain.Bus.Command;

namespace Armory.Flights.Application.Create
{
    public class CreateFlightCommand : Command
    {
        public CreateFlightCommand(string code, string name, string personId)
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
