using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Event;

namespace Armory.Shared.Domain.Formats.WarMaterialDeliveryCertificateFormats
{
    public class WarMaterialDeliveryCertificateFormatCreatedDomainEvent : DomainEvent
    {
        public WarMaterialDeliveryCertificateFormatCreatedDomainEvent(string aggregateId) : base(aggregateId)
        {
        }

        public IEnumerable<string> Weapons { get; init; }
        public IDictionary<string, int> Ammunition { get; init; }
        public IDictionary<string, int> Equipments { get; init; }
        public IDictionary<string, int> Explosives { get; init; }
        public string TroopId { get; init; }

        public override string EventName()
        {
            return "war_material_delivery_certificate_format.created";
        }
    }
}
