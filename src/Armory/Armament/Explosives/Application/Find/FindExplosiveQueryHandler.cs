using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.Find
{
    public class FindExplosiveQueryHandler : IQueryHandler<FindExplosiveQuery, ExplosiveResponse>
    {
        private readonly ExplosiveFinder _finder;

        public FindExplosiveQueryHandler(ExplosiveFinder finder)
        {
            _finder = finder;
        }

        public async Task<ExplosiveResponse> Handle(FindExplosiveQuery request, CancellationToken cancellationToken)
        {
            var explosive = await _finder.Find(request.Code);
            return explosive == null ? null : ExplosiveResponse.FromAggregate(explosive);
        }
    }
}
