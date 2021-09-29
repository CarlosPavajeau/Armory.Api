using System.Threading;
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

        public async Task<bool> Handle(CheckWeaponExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Serial);
        }
    }
}
