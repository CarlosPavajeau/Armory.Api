using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.CheckExists
{
    public class CheckSquadronExistsQueryHandler : IQueryHandler<CheckSquadronExistsQuery, bool>
    {
        private readonly SquadronExistsChecker _checker;

        public CheckSquadronExistsQueryHandler(SquadronExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckSquadronExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Code);
        }
    }
}
