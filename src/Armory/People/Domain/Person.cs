using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Degrees.Domain;
using Armory.Squadrons.Domain;
using Armory.Squads.Domain;
using Armory.Users.Domain;

namespace Armory.People.Domain
{
    public class Person
    {
        public Person(string id, string firstName, string secondName, string lastName, string secondLastName,
            string armoryUserId)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            ArmoryUserId = armoryUserId;
        }

        private Person()
        {
        }

        [Key] [MaxLength(10)] public string Id { get; set; }

        [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string SecondName { get; set; }
        [MaxLength(50)] public string LastName { get; set; }
        [MaxLength(50)] public string SecondLastName { get; set; }

        [NotMapped] public string FullName => $"{FirstName} {SecondName} {LastName} {SecondLastName}";

        public string ArmoryUserId { get; set; }

        [ForeignKey("ArmoryUserId")] public ArmoryUser ArmoryUser { get; set; }

        public int DegreeId { get; set; }
        [ForeignKey("DegreeId")] public Degree Degree { get; set; }

        public ICollection<Squadron> Squadrons { get; set; } = new HashSet<Squadron>();
        public ICollection<Squad> Squads { get; set; } = new HashSet<Squad>();

        public void Update(string firstName, string secondName, string lastName, string secondLastName)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
        }
    }
}
