using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Explosives.Domain;
using Armory.Armament.Weapons.Domain;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Aggregate;
using Armory.Squadrons.Domain;
using Armory.Squads.Domain;
using Armory.Troopers.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormat : AggregateRoot
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormat(string code, DateTime validity, string place,
            DateTime date, string squadronCode, string squadCode, string troopId, Warehouse warehouse,
            Purpose purpose, DocMovement docMovement, string physicalLocation, string others)
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

        [Key] public int Id { get; set; }

        [Required] [MaxLength(50)] public string Code { get; set; }
        [DataType(DataType.Date)] public DateTime Validity { get; set; }
        [Required] [MaxLength(256)] public string Place { get; set; }
        [DataType(DataType.Date)] public DateTime Date { get; set; }

        [Required] public string SquadronCode { get; set; }
        [ForeignKey("SquadronCode")] public Squadron Unit { get; set; }
        [Required] public string SquadCode { get; set; }
        [ForeignKey("SquadCode")] public Squad Dependency { get; set; }

        public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Applicant { get; set; }

        public Warehouse Warehouse { get; set; }
        public Purpose Purpose { get; set; }
        public DocMovement DocMovement { get; set; }

        [Required] [MaxLength(256)] public string PhysicalLocation { get; set; }
        [MaxLength(256)] public string Others { get; set; }

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>
            WarMaterialAndSpecialEquipmentAssignmentFormatWeapons { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>();

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition>
            WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition>();

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatEquipment>
            WarMaterialAndSpecialEquipmentAssignmentFormatEquipments { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatEquipment>();

        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatExplosive>
            WarMaterialAndSpecialEquipmentAssignmentFormatExplosives { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatExplosive>();

        [NotMapped] public ICollection<Weapon> Weapons { get; set; } = new HashSet<Weapon>();
        [NotMapped] public ICollection<Ammunition> Ammunition { get; set; } = new HashSet<Ammunition>();
        [NotMapped] public ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();
        [NotMapped] public ICollection<Explosive> Explosives { get; set; } = new HashSet<Explosive>();

        public static WarMaterialAndSpecialEquipmentAssignmentFormat Create(string code, DateTime validity,
            string place, DateTime date, string squadronCode, string squadCode, string troopId, Warehouse warehouse,
            Purpose purpose, DocMovement docMovement, string physicalLocation, string others,
            IEnumerable<string> weaponCodes, IDictionary<string, int> ammunition,
            IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = new WarMaterialAndSpecialEquipmentAssignmentFormat(code, validity, place, date, squadronCode,
                squadCode, troopId, warehouse, purpose, docMovement, physicalLocation, others);

            foreach (var weaponCode in weaponCodes)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatWeapons.Add(
                    WarMaterialAndSpecialEquipmentAssignmentFormatWeapon.Create(format, weaponCode));
            }

            foreach (var (ammunitionCode, quantity) in ammunition)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.Add(
                    Domain.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.Create(format, ammunitionCode,
                        quantity));
            }

            foreach (var (equipmentCode, quantity) in equipments)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments.Add(
                    WarMaterialAndSpecialEquipmentAssignmentFormatEquipment.Create(format, equipmentCode, quantity));
            }

            foreach (var (explosiveCode, quantity) in explosives)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives.Add(
                    WarMaterialAndSpecialEquipmentAssignmentFormatExplosive.Create(format, explosiveCode, quantity));
            }

            return format;
        }
    }
}
