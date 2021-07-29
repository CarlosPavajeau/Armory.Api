using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ResetPassword
{
    public class ResetPasswordCommandHandler : CommandHandler<ResetPasswordCommand>
    {
        private readonly PasswordRestorer _restorer;

        public ResetPasswordCommandHandler(PasswordRestorer restorer)
        {
            _restorer = restorer;
        }

        protected override async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await _restorer.ResetPassword(request.UsernameOrEmail, request.Token, request.NewPassword);
        }
    }
}
