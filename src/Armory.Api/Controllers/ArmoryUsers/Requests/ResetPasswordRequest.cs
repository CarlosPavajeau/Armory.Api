using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.ArmoryUsers.Requests
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "El token de reestablecimiento de contraseña es requerido.")]
        public string Token { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es requerida.")]
        public string NewPassword { get; set; }
    }
}
