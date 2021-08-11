using System;
using System.Collections.Generic;

namespace Armory.Api.Controllers.Formats.WarMaterialDeliveryCertificateFormats.Requests
{
    public class CreateWarMaterialDeliveryCertificateFormatRequest
    {
        public string Code { get; set; }
        public DateTime Validity { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }

        public string SquadronCode { get; set; }
        public string SquadCode { get; set; }
        public string TroopId { get; set; }

        public ICollection<string> Weapons { get; set; } = new HashSet<string>();
        public IDictionary<string, int> Ammunition { get; set; } = new Dictionary<string, int>();
        public IDictionary<string, int> Equipments { get; set; } = new Dictionary<string, int>();
        public IDictionary<string, int> Explosives { get; set; } = new Dictionary<string, int>();
    }
}
