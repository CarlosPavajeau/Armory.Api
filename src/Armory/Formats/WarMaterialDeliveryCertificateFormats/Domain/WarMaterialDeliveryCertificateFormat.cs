using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Explosives.Domain;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Aggregate;
using Armory.Squadrons.Domain;
using Armory.Squads.Domain;
using Armory.Troopers.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain
{
    public class WarMaterialDeliveryCertificateFormat : AggregateRoot
    {
        public WarMaterialDeliveryCertificateFormat(string code, DateTime validity, string place, DateTime date,
            string squadronCode, string squadCode, string troopId)
        {
            Code = code;
            Validity = validity;
            Place = place;
            Date = date;
            SquadronCode = squadronCode;
            SquadCode = squadCode;
            TroopId = troopId;
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
            DateTime date, string squadronCode, string squadCode, string troopId, IEnumerable<string> weaponCodes,
            IDictionary<string, int> ammunition, IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = new WarMaterialDeliveryCertificateFormat(code, validity, place, date, squadronCode, squadCode,
                troopId);

            var weapons = weaponCodes.ToList();
            foreach (var weaponCode in weapons)
            {
                format.WarMaterialDeliveryCertificateFormatWeapons.Add(
                    WarMaterialDeliveryCertificateFormatWeapon.Create(format, weaponCode));
            }

            foreach (var (ammunitionCode, quantity) in ammunition)
            {
                format.WarMaterialDeliveryCertificateFormatAmmunition.Add(
                    Domain.WarMaterialDeliveryCertificateFormatAmmunition.Create(format, ammunitionCode, quantity));
            }

            foreach (var (equipmentCode, quantity) in equipments)
            {
                format.WarMaterialDeliveryCertificateFormatEquipments.Add(
                    WarMaterialDeliveryCertificateFormatEquipment.Create(format, equipmentCode, quantity));
            }

            foreach (var (explosiveCode, quantity) in explosives)
            {
                format.WarMaterialDeliveryCertificateFormatExplosives.Add(
                    WarMaterialDeliveryCertificateFormatExplosive.Create(format, explosiveCode, quantity));
            }

            return format;
        }
    }
}
