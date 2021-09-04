using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Find
{
    public class FindAssignedWeaponMagazineFormatQueryHandler : IQueryHandler<FindAssignedWeaponMagazineFormatQuery,
        AssignedWeaponMagazineFormatResponse>
    {
        private readonly AssignedWeaponMagazineFormatFinder _finder;
        private readonly IMapper _mapper;

        public FindAssignedWeaponMagazineFormatQueryHandler(AssignedWeaponMagazineFormatFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<AssignedWeaponMagazineFormatResponse> Handle(FindAssignedWeaponMagazineFormatQuery request,
            CancellationToken cancellationToken)
        {
            var format = await _finder.Find(request.Id);

            return format == null ? null : _mapper.Map<AssignedWeaponMagazineFormatResponse>(format);
        }
    }
}
