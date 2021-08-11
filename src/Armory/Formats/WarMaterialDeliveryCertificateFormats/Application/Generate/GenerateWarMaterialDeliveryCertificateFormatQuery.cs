using System.IO;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate
{
    public class GenerateWarMaterialDeliveryCertificateFormatQuery : Query<MemoryStream>
    {
        public GenerateWarMaterialDeliveryCertificateFormatQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
