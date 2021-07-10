using System.ComponentModel.DataAnnotations;

namespace Armory.Armament.Equipments.Domain
{
    public class Equipment
    {
        [Key, MaxLength(50)] public string Code { get; set; }
        [Required, MaxLength(128)] public string Type { get; set; }
        [Required, MaxLength(256)] public string Model { get; set; }
        [Required, MaxLength(256)] public string Series { get; set; }
        [Required] public int QuantityAvailable { get; set; }

        public Equipment(string code, string type, string model, string series, int quantityAvailable)
        {
            Code = code;
            Type = type;
            Model = model;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public void Update(string type, string model, string series, int quantityAvailable)
        {
            Type = type;
            Model = model;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public static Equipment Create(string code, string type, string model, string series, int quantityAvailable)
        {
            return new(code, type, model, series, quantityAvailable);
        }
    }
}
