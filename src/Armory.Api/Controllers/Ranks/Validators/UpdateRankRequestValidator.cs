using Armory.Api.Controllers.Ranks.Requests;
using FluentValidation;

namespace Armory.Api.Controllers.Ranks.Validators
{
    public class UpdateRankRequestValidator : AbstractValidator<UpdateRankRequest>
    {
        public UpdateRankRequestValidator()
        {
            RuleFor(m => m.Id)
                .NotNull();

            RuleFor(m => m.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(256)
                .WithName("Nombre");
        }
    }
}
