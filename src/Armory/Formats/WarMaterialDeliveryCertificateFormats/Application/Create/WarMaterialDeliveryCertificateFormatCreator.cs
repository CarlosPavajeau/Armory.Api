using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Persistence.EntityFramework.Transactions;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create
{
    public class WarMaterialDeliveryCertificateFormatCreator
    {
        private readonly IEventBus _eventBus;
        private readonly ITransactionInitializer _initializer;
        private readonly IWarMaterialDeliveryCertificateFormatsRepository _repository;

        public WarMaterialDeliveryCertificateFormatCreator(IWarMaterialDeliveryCertificateFormatsRepository repository,
            IEventBus eventBus, ITransactionInitializer initializer)
        {
            _repository = repository;
            _eventBus = eventBus;
            _initializer = initializer;
        }

        public async Task<WarMaterialDeliveryCertificateFormat> Create(
            string code,
            DateTime validity,
            string place,
            DateTime date,
            string squadCode,
            string flightCode,
            string fireteamCode,
            string troopId,
            IEnumerable<string> weaponSerials,
            IDictionary<string, int> ammunition,
            IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = WarMaterialDeliveryCertificateFormat.Create(
                code,
                validity,
                place,
                date,
                squadCode,
                flightCode,
                fireteamCode,
                troopId,
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
