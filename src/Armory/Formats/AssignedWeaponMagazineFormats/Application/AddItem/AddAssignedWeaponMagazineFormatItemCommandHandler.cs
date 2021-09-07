using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using AutoMapper;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem
{
    public class
        AddAssignedWeaponMagazineFormatItemCommandHandler : ICommandHandler<AddAssignedWeaponMagazineFormatItemCommand,
            AssignedWeaponMagazineFormatItemResponse>
    {
        private readonly AssignedWeaponMagazineFormatItemAdder _adder;
        private readonly IMapper _mapper;

        public AddAssignedWeaponMagazineFormatItemCommandHandler(AssignedWeaponMagazineFormatItemAdder adder,
            IMapper mapper)
        {
            _adder = adder;
            _mapper = mapper;
        }

        public async Task<AssignedWeaponMagazineFormatItemResponse> Handle(
            AddAssignedWeaponMagazineFormatItemCommand request,
            CancellationToken cancellationToken)
        {
            var item = await _adder.AddItem(
                request.FormatId,
                request.TroopId,
                request.WeaponCode,
                request.SafetyCartridge,
                request.VerifiedInPhysical,
                request.Novelty,
                request.AmmunitionQuantity,
                request.AmmunitionLot,
                request.Observations);

            return _mapper.Map<AssignedWeaponMagazineFormatItemResponse>(item);
        }
    }
}
