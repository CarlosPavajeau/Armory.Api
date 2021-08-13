using System;
using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Event;

namespace Armory.Shared.Domain.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent : DomainEvent
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormatCreatedDomainEvent(IEnumerable<string> weaponCodes,
            IDictionary<string, int> ammunition, IDictionary<string, int> equipments,
            IDictionary<string, int> explosives, string troopId, string eventId = null,
            string occurredOn = null) : base(
            Guid.NewGuid().ToString(), eventId, occurredOn)
        {
            WeaponCodes = weaponCodes;
            Ammunition = ammunition;
            Equipments = equipments;
            Explosives = explosives;
            TroopId = troopId;
        }

        public IEnumerable<string> WeaponCodes { get; }
        public IDictionary<string, int> Ammunition { get; }
        public IDictionary<string, int> Equipments { get; }
        public IDictionary<string, int> Explosives { get; }
        public string TroopId { get; }

        public override string EventName()
        {
            return "war_material_and_special_equipment_assigment_format.created";
        }
    }
}
