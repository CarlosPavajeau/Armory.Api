using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.People.Domain;
using Armory.Squadrons.Domain;
using Armory.Troopers.Domain;

namespace Armory.Squads.Domain
{
    public class Squad
    {
        [Key, MaxLength(50)] public string Code { get; set; }
        [Required, MaxLength(128)] public string Name { get; set; }

        [Required] public string PersonId { get; set; }
        [ForeignKey("PersonId")] public Person Owner { get; set; }

        [Required] public string SquadronCode { get; set; }
        [ForeignKey("SquadronCode")] public Squadron Squadron { get; set; }

        public ICollection<Troop> Troopers { get; set; } = new HashSet<Troop>();

        public Squad(string code, string name, string personId, string squadronCode)
        {
            Code = code;
            Name = name;
            PersonId = personId;
            SquadronCode = squadronCode;
        }

        private Squad()
        {
        }

        public static Squad Create(string code, string name, string personId, string squadronCode)
        {
            return new(code, name, personId, squadronCode);
        }
    }
}
