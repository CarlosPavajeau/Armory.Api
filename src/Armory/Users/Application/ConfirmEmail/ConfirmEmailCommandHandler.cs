using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : CommandHandler<ConfirmEmailCommand>
    {
        private readonly EmailConfirmer _confirmer;

        public ConfirmEmailCommandHandler(EmailConfirmer confirmer)
        {
            _confirmer = confirmer;
        }

        protected override async Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            await _confirmer.ConfirmEmail(request.UsernameOrEmail, request.Token);
        }
    }
}
