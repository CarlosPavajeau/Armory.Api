using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Flights.Domain;
using Armory.People.Domain;
using Armory.Troopers.Domain;

namespace Armory.Fireteams.Domain
{
    public class Fireteam
    {
        public Fireteam(string code, string name, string personId, string flightCode)
        {
            Code = code;
            Name = name;
            PersonId = personId;
            FlightCode = flightCode;
        }

        private Fireteam()
        {
        }

        [Key] [MaxLength(50)] public string Code { get; set; }
        [Required] [MaxLength(128)] public string Name { get; set; }

        [Required] public string PersonId { get; set; }
        [ForeignKey("PersonId")] public Person Owner { get; set; }

        [Required] public string FlightCode { get; set; }
        [ForeignKey("FlightCode")] public Flight Flight { get; set; }

        public ICollection<Troop> Troopers { get; set; } = new HashSet<Troop>();
    }
}
