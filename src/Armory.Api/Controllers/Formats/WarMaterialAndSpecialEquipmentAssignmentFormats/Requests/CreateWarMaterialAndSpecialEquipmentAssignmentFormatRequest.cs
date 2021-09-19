using System;
using System.Collections.Generic;
using Armory.Formats.Shared.Application;
using Armory.Formats.Shared.Domain;

namespace Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Requests
{
    public class CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequest
    {
        public string Code { get; set; }
        public DateTime Validity { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }

        public string FlightCode { get; set; }
        public string FireteamCode { get; set; }
        public string TroopId { get; set; }

        public Warehouse Warehouse { get; set; }
        public Purpose Purpose { get; set; }
        public DocMovement DocMovement { get; set; }

        public string PhysicalLocation { get; set; }
        public string Others { get; set; }

        public ICollection<string> Weapons { get; set; }
        public ICollection<AmmunitionAndQuantity> Ammunition { get; set; }
        public ICollection<EquipmentAndQuantity> Equipments { get; set; }
        public ICollection<ExplosiveAndQuantity> Explosives { get; set; }
    }
}
