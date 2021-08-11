using System.Threading.Tasks;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public interface IWarMaterialDeliveryCertificateFormatsRepository
    {
        Task Save(WarMaterialDeliveryCertificateFormat format);
        Task<WarMaterialDeliveryCertificateFormat> Find(int id, bool noTracking = true);
    }
}
