using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.Find
{
    public class FindTroopQueryHandler : IQueryHandler<FindTroopQuery, TroopResponse>
    {
        private readonly TroopFinder _finder;

        public FindTroopQueryHandler(TroopFinder finder)
        {
            _finder = finder;
        }

        public async Task<TroopResponse> Handle(FindTroopQuery request, CancellationToken cancellationToken)
        {
            var troop = await _finder.Find(request.Id);
            return troop == null ? null : TroopResponse.FromAggregate(troop);
        }
    }
}
