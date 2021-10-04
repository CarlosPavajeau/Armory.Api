using Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests;
using FluentValidation;

namespace Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Validators
{
    public class
        CreateAssignedWeaponMagazineFormatRequestValidator : AbstractValidator<
            CreateAssignedWeaponMagazineFormatRequest>
    {
        public CreateAssignedWeaponMagazineFormatRequestValidator()
        {
            RuleFor(m => m.Code)
                .NotEmpty()
                .NotNull()
                .WithName("Format No.");

            RuleFor(m => m.Validity)
                .NotNull()
                .WithName("Vigencia");

            RuleFor(m => m.SquadCode)
                .NotEmpty()
                .NotNull()
                .WithName("Código de Escuadrón");

            RuleFor(m => m.FlightCode)
                .NotEmpty()
                .NotNull()
                .WithName("Código de Escuadrilla");

            RuleFor(m => m.FireteamCode)
                .NotEmpty()
                .NotNull()
                .WithName("Cóidigo de Escuadra");

            RuleFor(m => m.Warehouse)
                .NotNull()
                .WithName("Almacén de Armamento");

            RuleFor(m => m.Date)
                .NotNull()
                .WithName("Fecha");

            RuleFor(m => m.Comments)
                .NotEmpty()
                .NotNull()
                .WithName("Comentarios");
        }
    }
}
