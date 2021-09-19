using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Fireteams.Domain;
using Armory.People.Domain;

namespace Armory.Flights.Domain
{
    public class Flight
    {
        public Flight(string code, string name, string personId)
        {
            Code = code;
            Name = name;
            PersonId = personId;
        }

        private Flight()
        {
        }

        [Key] [MaxLength(50)] public string Code { get; set; }
        [Required] [MaxLength(128)] public string Name { get; set; }
        [Required] public string PersonId { get; set; }

        [ForeignKey("PersonId")] public Person Owner { get; set; }

        public ICollection<Fireteam> Fireteams { get; set; } = new HashSet<Fireteam>();
    }
}
