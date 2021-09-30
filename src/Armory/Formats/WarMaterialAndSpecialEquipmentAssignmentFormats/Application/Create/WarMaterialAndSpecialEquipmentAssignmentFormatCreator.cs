using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Formats.Shared.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatCreator
    {
        private readonly IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository _repository;

        public WarMaterialAndSpecialEquipmentAssignmentFormatCreator(
            IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarMaterialAndSpecialEquipmentAssignmentFormat> Create(
            string code,
            DateTime validity,
            string place,
            DateTime date,
            string squadCode,
            string flightCode,
            Warehouse warehouse,
            Purpose purpose,
            DocMovement docMovement,
            string physicalLocation,
            string others,
            IEnumerable<string> weaponSerials,
            IDictionary<string, int> ammunition,
            IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = WarMaterialAndSpecialEquipmentAssignmentFormat.Create(
                code,
                validity,
                place,
                date,
                squadCode,
                flightCode,
                warehouse,
                purpose,
                docMovement,
                physicalLocation,
                others,
                weaponSerials,
                ammunition,
                equipments,
                explosives);

            await _repository.Save(format);

            return format;
        }
    }
}
