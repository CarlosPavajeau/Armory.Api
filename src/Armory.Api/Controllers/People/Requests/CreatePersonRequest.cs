using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.People.Requests
{
    public class CreatePersonRequest
    {
        [Required(ErrorMessage = "La identificación de la persona es requerida.")]
        [MaxLength(10, ErrorMessage = "La identificación de la persona no debe tener más de 10 caracteres.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El primer nombre de la persona es requerido.")]
        [MaxLength(50, ErrorMessage = "El primer nombre de la persona no debe tener más de 50 caracteres.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo nombre de la persona no debe tener más de 50 caracteres.")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "El primer apellido de la persona es requerido.")]
        [MaxLength(50, ErrorMessage = "El primer aoellido de la persona no debe tener más de 50 caracteres.")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "El segundo apellido de la persona no debe tener más de 50 caracteres.")]
        public string SecondLastName { get; set; }

        [Required(ErrorMessage = "El email de la persona es requerido.")]
        [MaxLength(127, ErrorMessage = "El email de la persona no debe tener más de 127 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono de la persona es requerido.")]
        [MaxLength(127, ErrorMessage = "El número de teléfono de la persona no debe tener más de 10 caracteres.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El rol de la persona es requerido.")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "El grado de la persona es requerido.")]
        public int DegreeId { get; set; }
    }
}
