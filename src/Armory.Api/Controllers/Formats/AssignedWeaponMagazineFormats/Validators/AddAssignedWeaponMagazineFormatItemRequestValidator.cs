using Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests;
using FluentValidation;

namespace Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Validators
{
    public class
        AddAssignedWeaponMagazineFormatItemRequestValidator : AbstractValidator<
            AddAssignedWeaponMagazineFormatItemRequest>
    {
        public AddAssignedWeaponMagazineFormatItemRequestValidator()
        {
            RuleFor(m => m.FormatId)
                .NotEmpty()
                .NotNull()
                .WithName("Formato No.");

            RuleFor(m => m.TroopId)
                .NotEmpty()
                .NotNull()
                .WithName("Oficial, Suboficial o Soldado");

            RuleFor(m => m.WeaponSerial)
                .NotEmpty()
                .NotNull()
                .WithName("Arma");

            RuleFor(m => m.SafetyCartridge)
                .NotNull()
                .WithName("Cartucho de Seguridad");

            RuleFor(m => m.VerifiedInPhysical)
                .NotNull()
                .WithName("Verificado en físico");

            RuleFor(m => m.Novelty)
                .NotNull()
                .WithName("Novedad");

            RuleFor(m => m.AmmunitionQuantity)
                .NotNull()
                .WithName("Cantidad munición");

            RuleFor(m => m.AmmunitionLot)
                .NotEmpty()
                .NotNull()
                .WithName("Lote munición");

            RuleFor(m => m.Observations)
                .NotEmpty()
                .NotEmpty()
                .WithName("Observaciones");
        }
    }
}
