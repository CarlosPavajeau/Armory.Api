using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Armory.Degrees.Domain;

namespace Armory.Ranks.Domain
{
    public class Rank
    {
        public Rank(string name)
        {
            Name = name;
        }

        [Key] public int Id { get; set; }
        [Required] [MaxLength(256)] public string Name { get; set; }

        public ICollection<Degree> Degrees { get; set; } = new HashSet<Degree>();

        public static Rank Create(string name)
        {
            return new Rank(name);
        }
    }
}
