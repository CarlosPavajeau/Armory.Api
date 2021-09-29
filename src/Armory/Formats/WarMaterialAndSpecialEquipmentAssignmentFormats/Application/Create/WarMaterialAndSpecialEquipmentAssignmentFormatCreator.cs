using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Formats.Shared.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Persistence.EntityFramework.Transactions;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatCreator
    {
        private readonly IEventBus _eventBus;
        private readonly ITransactionInitializer _initializer;
        private readonly IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository _repository;

        public WarMaterialAndSpecialEquipmentAssignmentFormatCreator(
            IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository repository, IEventBus eventBus,
            ITransactionInitializer initializer)
        {
            _repository = repository;
            _eventBus = eventBus;
            _initializer = initializer;
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

            var transaction = await _initializer.Begin();

            await _repository.Save(format);
            await _eventBus.Publish(format.PullDomainEvents());

            await transaction.CommitAsync();

            return format;
        }
    }
}
