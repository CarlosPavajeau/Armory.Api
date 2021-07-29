using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.Find
{
    public class FindAmmunitionQueryHandler : IQueryHandler<FindAmmunitionQuery, AmmunitionResponse>
    {
        private readonly AmmunitionFinder _searcher;

        public FindAmmunitionQueryHandler(AmmunitionFinder searcher)
        {
            _searcher = searcher;
        }

        public async Task<AmmunitionResponse> Handle(FindAmmunitionQuery request, CancellationToken cancellationToken)
        {
            var ammunition = await _searcher.Find(request.Code);
            return ammunition == null ? null : AmmunitionResponse.FromAggregate(ammunition);
        }
    }
}
