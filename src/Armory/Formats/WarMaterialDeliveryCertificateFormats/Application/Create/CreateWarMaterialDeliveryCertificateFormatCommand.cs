using System;
using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create
{
    public class CreateWarMaterialDeliveryCertificateFormatCommand : Command<int>
    {
        public CreateWarMaterialDeliveryCertificateFormatCommand(string code, DateTime validity, string place,
            DateTime date, string squadronCode, string squadCode, string troopId)
        {
            Code = code;
            Validity = validity;
            Place = place;
            Date = date;
            SquadronCode = squadronCode;
            SquadCode = squadCode;
            TroopId = troopId;
        }

        public string Code { get; }
        public DateTime Validity { get; }
        public string Place { get; }
        public DateTime Date { get; }

        public string SquadronCode { get; }
        public string SquadCode { get; }
        public string TroopId { get; }

        public ICollection<string> Weapons { get; } = new HashSet<string>();
        public IDictionary<string, int> Ammunition { get; } = new Dictionary<string, int>();
        public IDictionary<string, int> Equipments { get; } = new Dictionary<string, int>();
        public IDictionary<string, int> Explosives { get; } = new Dictionary<string, int>();
    }
}
