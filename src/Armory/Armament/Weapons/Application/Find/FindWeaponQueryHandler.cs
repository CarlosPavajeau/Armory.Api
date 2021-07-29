using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.Find
{
    public class FindWeaponQueryHandler : IQueryHandler<FindWeaponQuery, WeaponResponse>
    {
        private readonly WeaponFinder _finder;

        public FindWeaponQueryHandler(WeaponFinder finder)
        {
            _finder = finder;
        }

        public async Task<WeaponResponse> Handle(FindWeaponQuery request, CancellationToken cancellationToken)
        {
            var weapon = await _finder.Find(request.Code);
            return weapon == null ? null : WeaponResponse.FromAggregate(weapon);
        }
    }
}
