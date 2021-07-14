using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Armament.Explosives.Requests
{
    public class CreateExplosiveRequest
    {
        [Required(ErrorMessage = "El código del explosivo es requerido.")]
        [MaxLength(50, ErrorMessage = "El código del referido no debe tener más de 50 caracteres.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El tipo de explosivo es requerido.")]
        [MaxLength(128, ErrorMessage = "El tipo de explosivo no debe tener más de 128 caracteres.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "El calibre del explosivo es requerido-")]
        [MaxLength(256, ErrorMessage = "El calibre del explosivo no debe tener más de 256 caracteres.")]
        public string Caliber { get; set; }

        [Required(ErrorMessage = "La marca del explosivo es requerido.")]
        [MaxLength(256, ErrorMessage = "La marca del explosivo no debe tener más de 256 caracteres.")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "El lote del explosivo es requerido.")]
        [MaxLength(256, ErrorMessage = "El lote del explosivo no debe tener más de 256 caracteres.")]
        public string Lot { get; set; }

        [Required(ErrorMessage = "El número de serie del explosivo es requerido.")]
        [MaxLength(256, ErrorMessage = "El número de serie del explosivo no debe tener más de 256 caracteres.")]
        public string Series { get; set; }

        [Required(ErrorMessage = "La cantidad disponible del explosivo es requerida.")]
        public int QuantityAvailable { get; set; }
    }
}
