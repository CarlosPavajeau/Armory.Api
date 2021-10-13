using Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Requests;
using FluentValidation;

namespace Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Validators
{
    public class
        CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequestValidator : AbstractValidator<
            CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequest>
    {
        public CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequestValidator()
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

            RuleFor(m => m.Warehouse)
                .NotNull()
                .WithName("Almacén de armamento");

            RuleFor(m => m.Purpose)
                .NotNull()
                .WithName("Finalidad");

            RuleFor(m => m.DocMovement)
                .NotNull()
                .WithName("Doc movimiento");

            RuleFor(m => m.PhysicalLocation)
                .NotEmpty()
                .NotNull()
                .WithName("Locación física");

            RuleFor(m => m.Others)
                .NotEmpty()
                .NotNull()
                .WithName("Otros");
        }
    }
}
