using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Weapons.Application.GenerateQR
{
    public class GenerateWeaponQrQueryHandler : IQueryHandler<GenerateWeaponQrQuery, MemoryStream>
    {
        private readonly WeaponQrGenerator _generator;

        public GenerateWeaponQrQueryHandler(WeaponQrGenerator generator)
        {
            _generator = generator;
        }

        public async Task<MemoryStream> Handle(GenerateWeaponQrQuery request, CancellationToken cancellationToken)
        {
            return await _generator.Generate(request.Code);
        }
    }
}
