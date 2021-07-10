using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Armament.Equipments.Requests
{
    public class UpdateEquipmentRequest
    {
        [Required(ErrorMessage = "El código del equipo especial o accesorio es requerido.")]
        [MaxLength(50, ErrorMessage = "El código del equipo especial o accesorio no debe tener más de 50 caracteres.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El tipo de equipo especial o accesorio es requerido.")]
        [MaxLength(128, ErrorMessage = "El tipo del equipo especial o accesorio no debe tener más de 128 caracteres.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "El modelo del equipo especial o accesorio es requerido.")]
        [MaxLength(256,
            ErrorMessage = "El modelo del equipo especial o accesorio no debe tener más de 256 caracteres.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "El número de serie del equipo especial o accesorio es requerido.")]
        [MaxLength(256,
            ErrorMessage = "El número de serie del equipo especial o accesorio no debe tener más de 256 caracteres.")]
        public string Series { get; set; }

        [Required(ErrorMessage = "La cantidad disponible del equipo especial o accesorio es requerido.")]
        public int QuantityAvailable { get; set; }
    }
}
