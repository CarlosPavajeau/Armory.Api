using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.CheckExists
{
    public class CheckWeaponExistsQueryHandler : IQueryHandler<CheckWeaponExistsQuery, bool>
    {
        private readonly WeaponExistsChecker _checker;

        public CheckWeaponExistsQueryHandler(WeaponExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckWeaponExistsQuery query)
        {
            return await _checker.Exists(query.Code);
        }
    }
}
