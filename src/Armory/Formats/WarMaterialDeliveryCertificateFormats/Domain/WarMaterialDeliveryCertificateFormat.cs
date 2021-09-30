using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Explosives.Domain;
using Armory.Armament.Weapons.Domain;
using Armory.Fireteams.Domain;
using Armory.Flights.Domain;
using Armory.Shared.Domain.Aggregate;
using Armory.Shared.Domain.Formats.WarMaterialDeliveryCertificateFormats;
using Armory.Squads.Domain;
using Armory.Troopers.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormat : AggregateRoot
    {
        public WarMaterialDeliveryCertificateFormat(string code, DateTime validity, string place, DateTime date,
            string squadCode, string flightCode, string fireteamCode, string troopId)
        {
            Code = code;
            Validity = validity;
            Place = place;
            Date = date;
            SquadCode = squadCode;
            FlightCode = flightCode;
            FireteamCode = fireteamCode;
            TroopId = troopId;
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

        [Required] public string FireteamCode { get; set; }
        [ForeignKey("FireteamCode")] public Fireteam Fireteam { get; set; }

        [Required] public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Receiver { get; set; }

        public ICollection<WarMaterialDeliveryCertificateFormatWeapon> WarMaterialDeliveryCertificateFormatWeapons
        {
            get;
            set;
        } = new HashSet<WarMaterialDeliveryCertificateFormatWeapon>();

        public ICollection<WarMaterialDeliveryCertificateFormatAmmunition>
            WarMaterialDeliveryCertificateFormatAmmunition { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormatAmmunition>();

        public ICollection<WarMaterialDeliveryCertificateFormatEquipment>
            WarMaterialDeliveryCertificateFormatEquipments { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormatEquipment>();

        public ICollection<WarMaterialDeliveryCertificateFormatExplosive>
            WarMaterialDeliveryCertificateFormatExplosives { get; set; } =
            new HashSet<WarMaterialDeliveryCertificateFormatExplosive>();

        [NotMapped] public ICollection<Weapon> Weapons { get; set; } = new HashSet<Weapon>();
        [NotMapped] public ICollection<Ammunition> Ammunition { get; set; } = new HashSet<Ammunition>();
        [NotMapped] public ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();
        [NotMapped] public ICollection<Explosive> Explosives { get; set; } = new HashSet<Explosive>();

        public static WarMaterialDeliveryCertificateFormat Create(string code, DateTime validity, string place,
            DateTime date, string squadCode, string flightCode, string fireteamCode, string troopId,
            IEnumerable<string> weaponSerials,
            IDictionary<string, int> ammunition, IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = new WarMaterialDeliveryCertificateFormat(code, validity, place, date, squadCode, flightCode,
                fireteamCode,
                troopId);

            var weapons = weaponSerials.ToList();
            foreach (var weaponSerial in weapons)
            {
                format.WarMaterialDeliveryCertificateFormatWeapons.Add(
                    WarMaterialDeliveryCertificateFormatWeapon.Create(format, weaponSerial));
            }

            foreach (var (ammunitionLot, quantity) in ammunition)
            {
                format.WarMaterialDeliveryCertificateFormatAmmunition.Add(
                    Domain.WarMaterialDeliveryCertificateFormatAmmunition.Create(format, ammunitionLot, quantity));
            }

            foreach (var (equipmentSerial, quantity) in equipments)
            {
                format.WarMaterialDeliveryCertificateFormatEquipments.Add(
                    WarMaterialDeliveryCertificateFormatEquipment.Create(format, equipmentSerial, quantity));
            }

            foreach (var (explosiveSerial, quantity) in explosives)
            {
                format.WarMaterialDeliveryCertificateFormatExplosives.Add(
                    WarMaterialDeliveryCertificateFormatExplosive.Create(format, explosiveSerial, quantity));
            }

            format.Record(new WarMaterialDeliveryCertificateFormatCreatedDomainEvent
            {
                Weapons = weapons,
                Ammunition = ammunition,
                Equipments = equipments,
                Explosives = explosives,
                TroopId = troopId
            });

            return format;
        }
    }
}
