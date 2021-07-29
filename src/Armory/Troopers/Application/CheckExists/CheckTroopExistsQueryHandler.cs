using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Troopers.Application.CheckExists
{
    public class CheckTroopExistsQueryHandler : IQueryHandler<CheckTroopExistsQuery, bool>
    {
        private readonly TroopExistsChecker _checker;

        public CheckTroopExistsQueryHandler(TroopExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckTroopExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Id);
        }
    }
}
