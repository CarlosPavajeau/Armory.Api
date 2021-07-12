using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Degrees.Requests
{
    public class CreateDegreeRequest
    {
        [Required(ErrorMessage = "El nombre del grado es requerido.")]
        [MaxLength(256, ErrorMessage = "El nombre del grado no puede tener más de 256 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El código del rango es requerido.")]
        public int RankId { get; set; }
    }
}
