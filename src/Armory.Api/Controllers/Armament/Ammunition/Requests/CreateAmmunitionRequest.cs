using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Armament.Ammunition.Requests
{
    public class CreateAmmunitionRequest
    {
        [Required(ErrorMessage = "El código de la munición es requerido.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El tipo de munición es requerido.")]
        [MaxLength(128, ErrorMessage = "El tipo de munición no debe terne más de 128 caracteres.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "La marca de la munición es requerida.")]
        [MaxLength(256, ErrorMessage = "La marca de la munición no debe tener más de 256 caracteres.")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "El calibre de la munición es requerida.")]
        [MaxLength(256, ErrorMessage = "El calibre de la munición no debe tener más de 256 caracteres.")]
        public string Caliber { get; set; }

        [Required(ErrorMessage = "El número de serie de la munición es requerido.")]
        [MaxLength(256, ErrorMessage = "El número de seria de la munición no debe tener más de 256 caracteres.")]
        public string Series { get; set; }

        [Required(ErrorMessage = "El lote de la munición es requerido.")]
        [MaxLength(256, ErrorMessage = "El lote de la munición no debe tener más de 256 caracteres.")]
        public string Lot { get; set; }

        [Required(ErrorMessage = "La cantidad disponible de la munición es requerida.")]
        public int QuantityAvailable { get; set; }
    }
}
