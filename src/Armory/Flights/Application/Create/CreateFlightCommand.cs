using Armory.Shared.Domain.Bus.Command;

namespace Armory.Flights.Application.Create
{
    public class CreateFlightCommand : Command
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public string PersonId { get; init; }
        public string SquadCode { get; init; }
    }
}
