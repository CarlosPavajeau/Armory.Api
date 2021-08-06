using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Aggregate;
using Armory.Squadrons.Domain;
using Armory.Squads.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Domain
{
    public class AssignedWeaponMagazineFormat : AggregateRoot
    {
        public AssignedWeaponMagazineFormat(string code, DateTime validity, string squadronCode,
            string squadCode, Warehouse warehouse, DateTime date, string comments)
        {
            Code = code;
            Validity = validity;
            SquadronCode = squadronCode;
            SquadCode = squadCode;
            Warehouse = warehouse;
            Date = date;
            Comments = comments;
        }

        [Key] public int Id { get; set; }

        [Required] [MaxLength(50)] public string Code { get; set; }
        [DataType(DataType.Date)] public DateTime Validity { get; set; }

        [Required] public string SquadronCode { get; set; }
        [ForeignKey("SquadronCode")] public Squadron Unit { get; set; }

        [Required] public string SquadCode { get; set; }
        [ForeignKey("SquadCode")] public Squad Dependency { get; set; }

        public Warehouse Warehouse { get; set; }
        [DataType(DataType.Date)] public DateTime Date { get; set; }

        [MaxLength(512)] public string Comments { get; set; }

        public ICollection<AssignedWeaponMagazineFormatItem> Records { get; set; } =
            new HashSet<AssignedWeaponMagazineFormatItem>();

        public static AssignedWeaponMagazineFormat Create(string code, DateTime validity, string squadronCode,
            string squadCode, Warehouse warehouse, DateTime date, string comments)
        {
            return new AssignedWeaponMagazineFormat(code, validity, squadCode, squadCode, warehouse, date, comments);
        }
    }
}
