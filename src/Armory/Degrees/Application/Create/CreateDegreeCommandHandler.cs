using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Degrees.Application.Create
{
    public class CreateDegreeCommandHandler : CommandHandler<CreateDegreeCommand>
    {
        private readonly DegreeCreator _creator;

        public CreateDegreeCommandHandler(DegreeCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateDegreeCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request);
        }
    }
}
