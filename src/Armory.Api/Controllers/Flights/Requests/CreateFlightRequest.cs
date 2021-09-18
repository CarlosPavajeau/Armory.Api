using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Flights.Requests
{
    public class CreateFlightRequest
    {
        [Required(ErrorMessage = "El código del escuadron es requerido.")]
        [MaxLength(50, ErrorMessage = "El código del escuadron no debe tener más de 50 caracteres.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El nombre del escuadron es requerido.")]
        [MaxLength(128, ErrorMessage = "El nombre del escuadron no debe tener más de 128 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La identificación de la persona a cargo es requerida.")]
        [MaxLength(10, ErrorMessage = "La identificación de la persona a cargo no debe tener más de 10 caracteres.")]
        public string PersonId { get; set; }
    }
}
