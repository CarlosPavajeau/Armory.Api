using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Flights.Application.CheckExists
{
    public class CheckFlightExistsQueryHandler : IQueryHandler<CheckFlightExistsQuery, bool>
    {
        private readonly FlightExistsChecker _checker;

        public CheckFlightExistsQueryHandler(FlightExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckFlightExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Code);
        }
    }
}
