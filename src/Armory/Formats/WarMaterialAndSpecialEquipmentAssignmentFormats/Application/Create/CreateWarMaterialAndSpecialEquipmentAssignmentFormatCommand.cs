using System;
using System.Collections.Generic;
using Armory.Formats.Shared.Application;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand : Command<int>
    {
        public string Code { get; init; }
        public DateTime Validity { get; init; }
        public string Place { get; init; }
        public DateTime Date { get; init; }

        public string SquadCode { get; init; }
        public string FlightCode { get; init; }

        public Warehouse Warehouse { get; init; }
        public Purpose Purpose { get; init; }
        public DocMovement DocMovement { get; init; }

        public string PhysicalLocation { get; init; }
        public string Others { get; init; }

        public IEnumerable<string> Weapons { get; } = new HashSet<string>();
        public IEnumerable<AmmunitionAndQuantity> Ammunition { get; } = new HashSet<AmmunitionAndQuantity>();
        public IEnumerable<EquipmentAndQuantity> Equipments { get; } = new HashSet<EquipmentAndQuantity>();
        public IEnumerable<ExplosiveAndQuantity> Explosives { get; } = new HashSet<ExplosiveAndQuantity>();
    }
}
