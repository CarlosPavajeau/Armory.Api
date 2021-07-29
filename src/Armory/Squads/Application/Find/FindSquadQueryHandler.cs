using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.Find
{
    public class FindSquadQueryHandler : IQueryHandler<FindSquadQuery, SquadResponse>
    {
        private readonly SquadFinder _finder;

        public FindSquadQueryHandler(SquadFinder finder)
        {
            _finder = finder;
        }

        public async Task<SquadResponse> Handle(FindSquadQuery request, CancellationToken cancellationToken)
        {
            var squad = await _finder.Find(request.Code);
            return squad == null ? null : SquadResponse.FromAggregate(squad);
        }
    }
}
