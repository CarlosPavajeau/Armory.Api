using System.Threading.Tasks;
using Armory.Flights.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;

namespace Armory.Flights.Application.UpdateCommander
{
    public class FlightCommanderUpdater
    {
        private readonly IUnitWork _unitWork;

        public FlightCommanderUpdater(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task UpdateCommander(Flight flight, string newCommander)
        {
            flight.PersonId = newCommander;
            await _unitWork.SaveChanges();
        }
    }
}
