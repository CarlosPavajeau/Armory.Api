using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.Find
{
    public class FindSquadronQueryHandler : IQueryHandler<FindSquadronQuery, SquadronResponse>
    {
        private readonly SquadronFinder _finder;

        public FindSquadronQueryHandler(SquadronFinder finder)
        {
            _finder = finder;
        }

        public async Task<SquadronResponse> Handle(FindSquadronQuery query)
        {
            var squadron = await _finder.Find(query.Code);
            return squadron == null ? null : SquadronResponse.FromAggregate(squadron);
        }
    }
}
