using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Troopers.Application.Create
{
    public class CreateTroopCommandHandler : CommandHandler<CreateTroopCommand>
    {
        private readonly TroopCreator _creator;

        public CreateTroopCommandHandler(TroopCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateTroopCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request.Id, request.FirstName, request.SecondName, request.LastName,
                request.SecondLastName, request.SquadCode, request.DegreeId);
        }
    }
}
