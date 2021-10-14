using Armory.Api.Controllers.Formats.WarMaterialDeliveryCertificateFormats.Requests;
using FluentValidation;

namespace Armory.Api.Controllers.Formats.WarMaterialDeliveryCertificateFormats.Validators
{
    public class
        CreateWarMaterialDeliveryCertificateFormatRequestValidator : AbstractValidator<
            CreateWarMaterialDeliveryCertificateFormatRequest>
    {
        public CreateWarMaterialDeliveryCertificateFormatRequestValidator()
        {
            RuleFor(m => m.Code)
                .NotEmpty()
                .NotNull()
                .WithName("Formato No.");

            RuleFor(m => m.Validity)
                .NotNull()
                .WithName("Vigencia");

            RuleFor(m => m.Place)
                .NotEmpty()
                .NotNull()
                .WithName("Lugar");

            RuleFor(m => m.Date)
                .NotNull()
                .WithName("Fecha");

            RuleFor(m => m.SquadCode)
                .NotEmpty()
                .NotNull()
                .WithName("Escuadrón");

            RuleFor(m => m.FlightCode)
                .NotEmpty()
                .NotNull()
                .WithName("Escuadrilla");

            RuleFor(m => m.FireteamCode)
                .NotEmpty()
                .NotNull()
                .WithName("Escuadra");

            RuleFor(m => m.TroopId)
                .NotEmpty()
                .NotNull()
                .WithName("Soldado, oficial, suboficial");
        }
    }
}
