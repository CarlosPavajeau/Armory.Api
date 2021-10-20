using Armory.Shared.Domain.Repositories;

namespace Armory.Flights.Domain
{
    public interface IFlightsRepository : IRepository<Flight, string>
    {
    }
}
