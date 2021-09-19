using System;
using System.Collections.Generic;
using Armory.Formats.Shared.Application;
using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create
{
    public class CreateWarMaterialDeliveryCertificateFormatCommand : Command<int>
    {
        public CreateWarMaterialDeliveryCertificateFormatCommand(string code, DateTime validity, string place,
            DateTime date, string flightCode, string fireteamCode, string troopId)
        {
            Code = code;
            Validity = validity;
            Place = place;
            Date = date;
            FlightCode = flightCode;
            FireteamCode = fireteamCode;
            TroopId = troopId;
        }

        public string Code { get; }
        public DateTime Validity { get; }
        public string Place { get; }
        public DateTime Date { get; }

        public string FlightCode { get; }
        public string FireteamCode { get; }
        public string TroopId { get; }

        public IEnumerable<string> Weapons { get; } = new HashSet<string>();
        public IEnumerable<AmmunitionAndQuantity> Ammunition { get; } = new HashSet<AmmunitionAndQuantity>();
        public IEnumerable<EquipmentAndQuantity> Equipments { get; } = new HashSet<EquipmentAndQuantity>();
        public IEnumerable<ExplosiveAndQuantity> Explosives { get; } = new HashSet<ExplosiveAndQuantity>();
    }
}
