using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Flights.Domain;
using Armory.People.Domain;

namespace Armory.Squads.Domain
{
    public class Squad
    {
        public Squad(string code, string name, string personId)
        {
            Code = code;
            Name = name;
            PersonId = personId;
        }

        private Squad()
        {
            // For EF
        }

        [Key] [MaxLength(50)] public string Code { get; set; }
        [Required] [MaxLength(128)] public string Name { get; set; }
        [Required] public string PersonId { get; set; }

        [ForeignKey("PersonId")] public Person Owner { get; set; }

        public ICollection<Flight> Flights { get; set; } = new HashSet<Flight>();
    }
}
