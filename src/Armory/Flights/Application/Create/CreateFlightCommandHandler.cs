using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Flights.Application.Create
{
    public class CreateFlightCommandHandler : CommandHandler<CreateFlightCommand>
    {
        private readonly FlightCreator _creator;

        public CreateFlightCommandHandler(FlightCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request);
        }
    }
}
