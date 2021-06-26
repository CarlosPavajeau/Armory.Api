using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Users.Domain;

namespace Armory.People.Domain
{
    public class Person
    {
        [Key, MaxLength(10)] public string Id { get; set; }

        [MaxLength(50)] public string FirstName { get; set; }
        [MaxLength(50)] public string SecondName { get; set; }
        [MaxLength(50)] public string LastName { get; set; }
        [MaxLength(50)] public string SecondLastName { get; set; }

        public string ArmoryUserId { get; set; }

        [ForeignKey("ArmoryUserId")] public ArmoryUser ArmoryUser { get; set; }

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

        public void Update(string firstName, string secondName, string lastName, string secondLastName)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
        }

        public static Person Create(string id, string firstName, string secondName, string lastName,
            string secondLastName, string armoryUserId)
        {
            return new(id, firstName, secondName, lastName, secondLastName, armoryUserId);
        }
    }
}