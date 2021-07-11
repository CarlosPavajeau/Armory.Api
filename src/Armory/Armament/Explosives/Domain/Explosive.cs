using System.ComponentModel.DataAnnotations;

namespace Armory.Armament.Explosives.Domain
{
    public class Explosive
    {
        [Key, MaxLength(50)] public string Code { get; set; }
        [Required, MaxLength(128)] public string Type { get; set; }
        [Required, MaxLength(256)] public string Caliber { get; set; }
        [Required, MaxLength(256)] public string Mark { get; set; }
        [Required, MaxLength(256)] public string Lot { get; set; }
        [Required, MaxLength(256)] public string Series { get; set; }
        [Required] public int QuantityAvailable { get; set; }

        public Explosive(string code, string type, string caliber, string mark, string lot, string series,
            int quantityAvailable)
        {
            Code = code;
            Type = type;
            Caliber = caliber;
            Mark = mark;
            Lot = lot;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public void Update(string type, string caliber, string mark, string lot, string series, int quantityAvailable)
        {
            Type = type;
            Caliber = caliber;
            Mark = mark;
            Lot = lot;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public static Explosive Create(string code, string type, string caliber, string mark, string lot, string series,
            int quantityAvailable)
        {
            return new(code, type, caliber, mark, lot, series, quantityAvailable);
        }
    }
}
