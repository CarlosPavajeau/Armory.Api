using System.Threading.Tasks;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Find
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatFinder
    {
        private readonly IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository _repository;

        public WarMaterialAndSpecialEquipmentAssignmentFormatFinder(
            IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarMaterialAndSpecialEquipmentAssignmentFormat> Find(int id)
        {
            return await _repository.Find(id);
        }
    }
}
