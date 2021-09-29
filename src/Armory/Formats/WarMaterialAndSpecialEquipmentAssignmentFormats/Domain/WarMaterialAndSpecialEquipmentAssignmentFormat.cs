using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Explosives.Domain;
using Armory.Armament.Weapons.Domain;
using Armory.Flights.Domain;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Aggregate;
using Armory.Squads.Domain;

namespace Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain
{
    public class WarMaterialAndSpecialEquipmentAssignmentFormat : AggregateRoot
    {
        public WarMaterialAndSpecialEquipmentAssignmentFormat(string code, DateTime validity, string place,
            DateTime date, string squadCode, string flightCode, Warehouse warehouse, Purpose purpose,
            DocMovement docMovement, string physicalLocation, string others)
        {
            Code = code;
            Validity = validity;
            Place = place;
            Date = date;
            SquadCode = squadCode;
            FlightCode = flightCode;
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

        [Required] public string SquadCode { get; set; }
        [ForeignKey("SquadCode")] public Squad Squad { get; set; }

        [Required] public string FlightCode { get; set; }
        [ForeignKey("FlightCode")] public Flight Flight { get; set; }

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
            string place, DateTime date, string squadCode, string flightCode, Warehouse warehouse,
            Purpose purpose, DocMovement docMovement, string physicalLocation, string others,
            IEnumerable<string> weaponSerials, IDictionary<string, int> ammunition,
            IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = new WarMaterialAndSpecialEquipmentAssignmentFormat(code, validity, place, date, squadCode,
                flightCode, warehouse, purpose, docMovement, physicalLocation, others);

            var weapons = weaponSerials.ToList();
            foreach (var weaponSerial in weapons)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatWeapons.Add(
                    WarMaterialAndSpecialEquipmentAssignmentFormatWeapon.Create(format, weaponSerial));
            }

            foreach (var (ammunitionLot, quantity) in ammunition)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.Add(
                    Domain.WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition.Create(format, ammunitionLot,
                        quantity));
            }

            foreach (var (equipmentSerial, quantity) in equipments)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatEquipments.Add(
                    WarMaterialAndSpecialEquipmentAssignmentFormatEquipment.Create(format, equipmentSerial, quantity));
            }

            foreach (var (explosiveSerial, quantity) in explosives)
            {
                format.WarMaterialAndSpecialEquipmentAssignmentFormatExplosives.Add(
                    WarMaterialAndSpecialEquipmentAssignmentFormatExplosive.Create(format, explosiveSerial, quantity));
            }

            return format;
        }
    }
}
