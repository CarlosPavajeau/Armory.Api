using System.ComponentModel.DataAnnotations;

namespace Armory.Squadron.Domain
{
    public class Squadron
    {
        [Key, MaxLength(50)] public string Code { get; set; }
        [Required, MaxLength(128)] public string Name { get; set; }
        [Required] public string ArmoryUserId { get; set; }

        public Squadron(string code, string name, string armoryUserId)
        {
            Code = code;
            Name = name;
            ArmoryUserId = armoryUserId;
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
