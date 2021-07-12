using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Troopers.Requests
{
    public class CreateTroopRequest
    {
        [Required(ErrorMessage = "La identificación de la tropa es requerida.")]
        [MaxLength(10, ErrorMessage = "La identificación de la tropa no debe tener más de 10 caracteres.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El primer nombre de la tropa es requerido.")]
        [MaxLength(50, ErrorMessage = "El primer nombre de la tropa no debe tener más de 50 caracteres.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo nombre de la tropa no debe tener más de 50 caracteres.")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El primer apellido de la tropa es requerido.")]
        [MaxLength(50, ErrorMessage = "El primer aoellido de la tropa no debe tener más de 50 caracteres.")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo apellido de la tropa no debe tener más de 50 caracteres.")]
        public string SecondLastName { get; set; }

        [Required(ErrorMessage = "El código del escruadron al que pertenece la tropa es requerido.")]
        [MaxLength(50, ErrorMessage = "El código del escuadron no debe tener más de 50 caracteres.")]
        public string SquadCode { get; set; }

        [Required(ErrorMessage = "El código del grado de la tropa es requerido.")]
        public int DegreeId { get; set; }
    }
}
