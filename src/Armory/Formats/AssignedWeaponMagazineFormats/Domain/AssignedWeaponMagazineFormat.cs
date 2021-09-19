using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Fireteams.Domain;
using Armory.Flights.Domain;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Aggregate;
using Armory.Squads.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    public class AssignedWeaponMagazineFormat : AggregateRoot
    {
        public AssignedWeaponMagazineFormat(string code, DateTime validity, string squadCode, string flightCode,
            string fireteamCode, Warehouse warehouse, DateTime date, string comments)
        {
            Code = code;
            Validity = validity;
            SquadCode = squadCode;
            FlightCode = flightCode;
            FireteamCode = fireteamCode;
            Warehouse = warehouse;
            Date = date;
            Comments = comments;
        }

        [Key] public int Id { get; set; }

        [Required] [MaxLength(50)] public string Code { get; set; }
        [DataType(DataType.Date)] public DateTime Validity { get; set; }

        [Required] public string SquadCode { get; set; }
        [ForeignKey("SquadCode")] public Squad Squad { get; set; }

        [Required] public string FlightCode { get; set; }
        [ForeignKey("FlightCode")] public Flight Flight { get; set; }

        [Required] public string FireteamCode { get; set; }
        [ForeignKey("FireteamCode")] public Fireteam Fireteam { get; set; }

        public Warehouse Warehouse { get; set; }
        [DataType(DataType.Date)] public DateTime Date { get; set; }

        [MaxLength(512)] public string Comments { get; set; }

        public ICollection<AssignedWeaponMagazineFormatItem> Records { get; set; } =
            new HashSet<AssignedWeaponMagazineFormatItem>();
    }
}
