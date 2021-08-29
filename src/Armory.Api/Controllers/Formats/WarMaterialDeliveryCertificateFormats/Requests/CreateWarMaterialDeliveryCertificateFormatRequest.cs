using System;
using System.Collections.Generic;
using Armory.Formats.Shared.Application;

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

        public ICollection<string> Weapons { get; set; }
        public ICollection<AmmunitionAndQuantity> Ammunition { get; set; }
        public ICollection<EquipmentAndQuantity> Equipments { get; set; }
        public ICollection<ExplosiveAndQuantity> Explosives { get; set; }
    }
}
