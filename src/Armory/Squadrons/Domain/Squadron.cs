using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.People.Domain;
using Armory.Squads.Domain;

namespace Armory.Squadrons.Domain
{
    public class Squadron
    {
        [Key, MaxLength(50)] public string Code { get; set; }
        [Required, MaxLength(128)] public string Name { get; set; }
        [Required] public string PersonId { get; set; }

        [ForeignKey("PersonId")] public Person Owner { get; set; }

        public ICollection<Squad> Squads { get; set; } = new HashSet<Squad>();

        public Squadron(string code, string name, string personId)
        {
            Code = code;
            Name = name;
            PersonId = personId;
        }

        private Squadron()
        {
        }

        public static Squadron Create(string code, string name, string armoryUserId)
        {
            var squadron = new Squadron(code, name, armoryUserId);
            return squadron;
        }
    }
}
