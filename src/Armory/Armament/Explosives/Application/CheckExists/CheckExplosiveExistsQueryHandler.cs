using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.CheckExists
{
    public class CheckExplosiveExistsQueryHandler : IQueryHandler<CheckExplosiveExistsQuery, bool>
    {
        private readonly ExplosiveExistsChecker _checker;

        public CheckExplosiveExistsQueryHandler(ExplosiveExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckExplosiveExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Code);
        }
    }
}
