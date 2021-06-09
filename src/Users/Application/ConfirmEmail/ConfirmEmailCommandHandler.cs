using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : ICommandHandler<ConfirmEmailCommand>
    {
        private readonly EmailConfirmer _confirmer;

        public ConfirmEmailCommandHandler(EmailConfirmer confirmer)
        {
            _confirmer = confirmer;
        }

        public async Task Handle(ConfirmEmailCommand command)
        {
            await _confirmer.ConfirmEmail(command.UsernameOrEmail, command.Token);
        }
    }
}
