using Armory.Shared.Domain.Bus.Command;

namespace Armory.Flights.Application.UpdateCommander
{
    public class UpdateFlightCommanderCommand : Command
    {
        public string Code { get; init; }
        public string PersonId { get; init; }
    }
}
