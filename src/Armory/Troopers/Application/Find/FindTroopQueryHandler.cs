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

        public async Task<TroopResponse> Handle(FindTroopQuery query)
        {
            var troop = await _finder.Find(query.Id);
            return troop == null ? null : TroopResponse.FromAggregate(troop);
        }
    }
}
