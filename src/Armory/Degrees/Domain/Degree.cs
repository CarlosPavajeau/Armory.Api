using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.People.Domain;
using Armory.Ranks.Domain;
using Armory.Troopers.Domain;

namespace Armory.Degrees.Domain
{
    public class Degree
    {
        public Degree(string name, int rankId)
        {
            Name = name;
            RankId = rankId;
        }

        [Key] public int Id { get; set; }
        [Required] [MaxLength(256)] public string Name { get; set; }

        public int RankId { get; set; }

        [ForeignKey("RankId")] public Rank Rank { get; set; }

        public ICollection<Troop> Troopers { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
