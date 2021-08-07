using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Find;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Generate
{
    public class GenerateWarMaterialAndSpecialEquipmentAssignmentFormatQueryHandler : IQueryHandler<
        GenerateWarMaterialAndSpecialEquipmentAssignmentFormatQuery, MemoryStream>
    {
        private readonly WarMaterialAndSpecialEquipmentAssignmentFormatFinder _finder;
        private readonly WarMaterialAndSpecialEquipmentAssignmentFormatGenerator _generator;

        public GenerateWarMaterialAndSpecialEquipmentAssignmentFormatQueryHandler(
            WarMaterialAndSpecialEquipmentAssignmentFormatGenerator generator,
            WarMaterialAndSpecialEquipmentAssignmentFormatFinder finder)
        {
            _generator = generator;
            _finder = finder;
        }

        public async Task<MemoryStream> Handle(GenerateWarMaterialAndSpecialEquipmentAssignmentFormatQuery request,
            CancellationToken cancellationToken)
        {
            var format = await _finder.Find(request.Id);
            var stream = _generator.Generate(format);

            return stream;
        }
    }
}
