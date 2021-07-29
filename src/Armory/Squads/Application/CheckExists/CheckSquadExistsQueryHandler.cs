using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.CheckExists
{
    public class CheckSquadExistsQueryHandler : IQueryHandler<CheckSquadExistsQuery, bool>
    {
        private readonly SquadExistsChecker _checker;

        public CheckSquadExistsQueryHandler(SquadExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckSquadExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Code);
        }
    }
}
