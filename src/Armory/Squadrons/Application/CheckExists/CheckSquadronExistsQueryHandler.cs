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

        public async Task<bool> Handle(CheckSquadronExistsQuery query)
        {
            return await _checker.Exists(query.Code);
        }
    }
}
