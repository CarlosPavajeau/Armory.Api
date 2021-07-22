using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.CheckExists
{
    public class CheckAmmunitionExistsQueryHandler : IQueryHandler<CheckAmmunitionExistsQuery, bool>
    {
        private readonly AmmunitionExistsChecker _checker;

        public CheckAmmunitionExistsQueryHandler(AmmunitionExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckAmmunitionExistsQuery query)
        {
            return await _checker.Exists(query.Code);
        }
    }
}
