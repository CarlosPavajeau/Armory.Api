using System.Threading.Tasks;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Find
{
    public class WarMaterialDeliveryCertificateFormatFinder
    {
        private readonly IWarMaterialDeliveryCertificateFormatsRepository _repository;

        public WarMaterialDeliveryCertificateFormatFinder(IWarMaterialDeliveryCertificateFormatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarMaterialDeliveryCertificateFormat> Find(int id)
        {
            return await _repository.Find(id);
        }
    }
}
