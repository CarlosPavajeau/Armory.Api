using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Fireteams.Requests;

public class UpdateFireTeamRequest
{
    [Required(ErrorMessage = "El nombre de la escuadra es requerido.")]
    [MaxLength(128, ErrorMessage = "El nombre de la escuadra no debe tener más de 128 caracteres.")]
    public string Name { get; set; }
}
