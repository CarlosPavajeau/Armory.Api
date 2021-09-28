using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Weapons.Domain;
using Armory.Degrees.Domain;
using Armory.Fireteams.Domain;

namespace Armory.Troopers.Domain
{
    public class Troop
    {
        public Troop(string id, string firstName, string secondName, string lastName, string secondLastName,
            string fireteamCode, int degreeId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            FireteamCode = fireteamCode;
            DegreeId = degreeId;
        }

        [Key] [MaxLength(10)] public string Id { get; set; }
        [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string SecondName { get; set; }
        [MaxLength(50)] public string LastName { get; set; }
        [MaxLength(50)] public string SecondLastName { get; set; }

        [NotMapped] public string FullName => $"{FirstName} {SecondName} {LastName} {SecondLastName}";

        public string FireteamCode { get; set; }
        [ForeignKey("FireteamCode")] public Fireteam Fireteam { get; set; }

        public int DegreeId { get; set; }
        [ForeignKey("DegreeId")] public Degree Degree { get; set; }

        public ICollection<Weapon> Weapons { get; set; } = new HashSet<Weapon>();
        public ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();

        public void Update(string firstName, string secondName, string lastName, string secondLastName)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
        }
    }
}
