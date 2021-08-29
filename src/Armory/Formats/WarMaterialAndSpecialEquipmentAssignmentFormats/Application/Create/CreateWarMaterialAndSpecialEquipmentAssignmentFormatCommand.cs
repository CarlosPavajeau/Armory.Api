using System;
using System.Collections.Generic;
using Armory.Formats.Shared.Application;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand : Command<int>
    {
        public CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand(string code, DateTime validity, string place,
            DateTime date, string squadronCode, string squadCode, string troopId, Warehouse warehouse, Purpose purpose,
            DocMovement docMovement, string physicalLocation, string others)
        {
            Code = code;
            Validity = validity;
            Place = place;
            Date = date;
            SquadronCode = squadronCode;
            SquadCode = squadCode;
            TroopId = troopId;
            Warehouse = warehouse;
            Purpose = purpose;
            DocMovement = docMovement;
            PhysicalLocation = physicalLocation;
            Others = others;
        }

        public string Code { get; }
        public DateTime Validity { get; }
        public string Place { get; }
        public DateTime Date { get; }

        public string SquadronCode { get; }
        public string SquadCode { get; }
        public string TroopId { get; }

        public Warehouse Warehouse { get; }
        public Purpose Purpose { get; }
        public DocMovement DocMovement { get; }

        public string PhysicalLocation { get; }
        public string Others { get; }

        public IEnumerable<string> Weapons { get; } = new HashSet<string>();
        public IEnumerable<AmmunitionAndQuantity> Ammunition { get; } = new HashSet<AmmunitionAndQuantity>();
        public IEnumerable<EquipmentAndQuantity> Equipments { get; } = new HashSet<EquipmentAndQuantity>();
        public IEnumerable<ExplosiveAndQuantity> Explosives { get; } = new HashSet<ExplosiveAndQuantity>();
    }
}
