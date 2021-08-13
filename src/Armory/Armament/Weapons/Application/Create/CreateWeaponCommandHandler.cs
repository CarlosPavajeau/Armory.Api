using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Weapons.Application.Create
{
    public class CreateWeaponCommandHandler : ICommandHandler<CreateWeaponCommand, string>
    {
        private readonly WeaponCreator _creator;

        public CreateWeaponCommandHandler(WeaponCreator creator)
        {
            _creator = creator;
        }

        public async Task<string> Handle(CreateWeaponCommand request, CancellationToken cancellationToken)
        {
            var weapon = await _creator.Create(request.Code, request.Type, request.Mark, request.Model, request.Caliber,
                request.Series, request.Lot, request.NumberOfProviders, request.ProviderCapacity);

            return weapon.Code;
        }
    }
}
