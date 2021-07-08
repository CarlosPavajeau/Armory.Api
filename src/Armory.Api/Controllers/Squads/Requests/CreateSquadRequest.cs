using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Squads.Requests
{
    public class CreateSquadRequest
    {
        [Required(ErrorMessage = "El código de la escuadra es requerido.")]
        [MaxLength(50, ErrorMessage = "El código de la escuadra no debe tener más de 50 caracteres.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El nombre de la escuadra es requerido.")]
        [MaxLength(128, ErrorMessage = "El nombre de la escuadra no debe tener más de 128 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La identificación de la persona a cargo es requerida.")]
        [MaxLength(10, ErrorMessage = "La identificación de la persona a cargo no debe tener más de 10 caracteres.")]
        public string PersonId { get; set; }

        [Required(ErrorMessage = "El código de la escuadrilla es requerido.")]
        [MaxLength(50, ErrorMessage = "El código de la escuadrilla no debe tener más de 50 caracteres.")]
        public string SquadronCode { get; set; }
    }
}
