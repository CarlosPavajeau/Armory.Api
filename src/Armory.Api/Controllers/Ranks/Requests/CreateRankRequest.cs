using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Ranks.Requests
{
    public class CreateRankRequest
    {
        [Required(ErrorMessage = "El nombre del rango es requerido.")]
        [MaxLength(256, ErrorMessage = "El nombre del rango no puede tener más de 256 caracteres.")]
        public string Name { get; set; }
    }
}
