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

        public async Task<bool> Handle(CheckSquadExistsQuery query)
        {
            return await _checker.Exists(query.Code);
        }
    }
}
