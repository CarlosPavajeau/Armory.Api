using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ResetPassword
{
    public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand>
    {
        private readonly PasswordRestorer _restorer;

        public ResetPasswordCommandHandler(PasswordRestorer restorer)
        {
            _restorer = restorer;
        }

        public async Task Handle(ResetPasswordCommand command)
        {
            await _restorer.ResetPassword(command.UsernameOrEmail, command.Token, command.NewPassword);
        }
    }
}
