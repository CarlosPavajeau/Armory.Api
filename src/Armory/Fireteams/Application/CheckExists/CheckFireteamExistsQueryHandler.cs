using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Fireteams.Application.CheckExists
{
    public class CheckFireteamExistsQueryHandler : IQueryHandler<CheckFireteamExistsQuery, bool>
    {
        private readonly FireteamExistsChecker _checker;

        public CheckFireteamExistsQueryHandler(FireteamExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckFireteamExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Code);
        }
    }
}
