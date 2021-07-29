using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ChangePassword
{
    public class ChangePasswordCommandHandler : CommandHandler<ChangePasswordCommand>
    {
        private readonly PasswordChanger _changer;

        public ChangePasswordCommandHandler(PasswordChanger changer)
        {
            _changer = changer;
        }

        protected override async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await _changer.ChangePassword(request.UsernameOrEmail, request.OldPassword, request.NewPassword);
        }
    }
}
