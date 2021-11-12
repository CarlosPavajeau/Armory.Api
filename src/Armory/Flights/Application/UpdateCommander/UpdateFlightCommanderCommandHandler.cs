using System.Threading;
using System.Threading.Tasks;
using Armory.Flights.Application.Find;
using Armory.Flights.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Flights.Application.UpdateCommander
{
    public class UpdateFlightCommanderCommandHandler : CommandHandler<UpdateFlightCommanderCommand>
    {
        private readonly FlightFinder _finder;
        private readonly FlightCommanderUpdater _updater;

        public UpdateFlightCommanderCommandHandler(FlightFinder finder, FlightCommanderUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdateFlightCommanderCommand request, CancellationToken cancellationToken)
        {
            var flight = await _finder.Find(request.Code, false);
            if (flight == null)
            {
                throw new FlightNotFoundException();
            }

            await _updater.UpdateCommander(flight, request.PersonId);
        }
    }
}
