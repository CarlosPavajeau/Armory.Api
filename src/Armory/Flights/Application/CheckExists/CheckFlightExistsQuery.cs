using Armory.Shared.Domain.Bus.Query;

namespace Armory.Flights.Application.CheckExists
{
    public class CheckFlightExistsQuery : Query<bool>
    {
        public CheckFlightExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
