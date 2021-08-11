using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Find;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate
{
    public class
        GenerateWarMaterialDeliveryCertificateFormatQueryHandler : IQueryHandler<
            GenerateWarMaterialDeliveryCertificateFormatQuery, MemoryStream>
    {
        private readonly WarMaterialDeliveryCertificateFormatFinder _finder;
        private readonly WarMaterialDeliveryCertificateFormatGenerator _generator;

        public GenerateWarMaterialDeliveryCertificateFormatQueryHandler(
            WarMaterialDeliveryCertificateFormatFinder finder, WarMaterialDeliveryCertificateFormatGenerator generator)
        {
            _finder = finder;
            _generator = generator;
        }

        public async Task<MemoryStream> Handle(GenerateWarMaterialDeliveryCertificateFormatQuery request,
            CancellationToken cancellationToken)
        {
            var format = await _finder.Find(request.Id);
            var stream = _generator.Generate(format);

            return stream;
        }
    }
}
