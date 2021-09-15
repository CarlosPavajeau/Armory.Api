using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.People.Requests
{
    public class UpdatePersonDegreeRequest
    {
        [Required(ErrorMessage = "La identificación de la persona es requerida.")]
        [MaxLength(10, ErrorMessage = "La identificación de la persona no debe tener más de 10 caracteres.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El grado de la persona es requerido.")]
        public int DegreeId { get; set; }
    }
}
