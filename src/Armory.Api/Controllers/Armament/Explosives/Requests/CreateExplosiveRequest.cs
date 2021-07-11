using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Armament.Explosives.Requests
{
    public class CreateExplosiveRequest
    {
        [Required(ErrorMessage = "")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required(ErrorMessage = "")]
        [MaxLength(128)]
        public string Type { get; set; }

        [Required(ErrorMessage = "")]
        [MaxLength(256)]
        public string Caliber { get; set; }

        [Required(ErrorMessage = "")]
        [MaxLength(256)]
        public string Mark { get; set; }

        [Required(ErrorMessage = "")]
        [MaxLength(256)]
        public string Lot { get; set; }

        [Required(ErrorMessage = "")]
        [MaxLength(256)]
        public string Series { get; set; }

        [Required(ErrorMessage = "")]
        public int QuantityAvailable { get; set; }
    }
}
