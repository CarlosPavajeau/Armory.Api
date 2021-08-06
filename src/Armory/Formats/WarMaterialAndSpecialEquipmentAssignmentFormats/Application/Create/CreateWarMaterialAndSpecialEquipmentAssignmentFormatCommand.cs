using System;
using System.Collections.Generic;
using System.IO;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create
{
    public class CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand : Command<MemoryStream>
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

        public ICollection<string> Weapons { get; } = new HashSet<string>();
        public IDictionary<string, int> Ammunition { get; } = new Dictionary<string, int>();
        public IDictionary<string, int> Equipments { get; } = new Dictionary<string, int>();
        public IDictionary<string, int> Explosives { get; } = new Dictionary<string, int>();
    }
}
