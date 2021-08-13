using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Find;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate
{
    public class
        GenerateAssignedWeaponMagazineFormatQueryHandler : IQueryHandler<GenerateAssignedWeaponMagazineFormatQuery,
            MemoryStream>
    {
        private readonly AssignedWeaponMagazineFormatFinder _finder;
        private readonly AssignedWeaponMagazineFormatGenerator _generator;

        public GenerateAssignedWeaponMagazineFormatQueryHandler(AssignedWeaponMagazineFormatFinder finder,
            AssignedWeaponMagazineFormatGenerator generator)
        {
            _finder = finder;
            _generator = generator;
        }

        public async Task<MemoryStream> Handle(GenerateAssignedWeaponMagazineFormatQuery request,
            CancellationToken cancellationToken)
        {
            var format = await _finder.Find(request.Id);
            var stream = _generator.Generate(format);

            return stream;
        }
    }
}
