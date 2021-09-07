using System;
using System.Collections.Generic;
using Armory.Formats.Shared.Domain;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application
{
    public class AssignedWeaponMagazineFormatResponse
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public DateTime Validity { get; init; }
        public string SquadronCode { get; init; }
        public string SquadCode { get; init; }
        public Warehouse Warehouse { get; init; }
        public DateTime Date { get; init; }
        public string Comments { get; init; }

        public IEnumerable<AssignedWeaponMagazineFormatItemResponse> Records { get; init; }
    }
}
