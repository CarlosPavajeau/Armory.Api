using System.ComponentModel.DataAnnotations;

namespace Armory.Api.Controllers.Armament.Weapons.Requests
{
    public class UpdateWeaponRequest
    {
        [Required(ErrorMessage = "El tipo de arma es requerido.")]
        [MaxLength(128, ErrorMessage = "El tipo de arma no debe tener más de 128 caracteres.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "El tipo de arma es requerido.")]
        [MaxLength(256, ErrorMessage = "El tipo de arma no debe tener más de 128 caracteres.")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "La marca del arma es requerido.")]
        [MaxLength(256, ErrorMessage = "La marca del arma no debe tener más de 256 caracteres.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "El calibre del arma es requerido.")]
        [MaxLength(256, ErrorMessage = "El calibre del arma no debe tener más de 256 caracteres.")]
        public string Caliber { get; set; }

        [Required(ErrorMessage = "El número de proveedores del arma es requerido.")]
        public int NumberOfProviders { get; set; }

        [Required(ErrorMessage = "La capacidad de proveedor del arma es requerida.")]
        public int ProviderCapacity { get; set; }
    }
}
