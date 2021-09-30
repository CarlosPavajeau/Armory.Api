using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Armament.Weapons.Application.Find
{
    public class FindWeaponQueryHandler : IQueryHandler<FindWeaponQuery, WeaponResponse>
    {
        private readonly WeaponFinder _finder;
        private readonly IMapper _mapper;

        public FindWeaponQueryHandler(WeaponFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<WeaponResponse> Handle(FindWeaponQuery request, CancellationToken cancellationToken)
        {
            var weapon = await _finder.Find(request.Serial);
            return weapon == null ? null : _mapper.Map<WeaponResponse>(weapon);
        }
    }
}
