using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.ArmoryUsers.Requests
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "La contraseña antigua es requerida.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es requerida.")]
        public string NewPassword { get; set; }
    }
}
