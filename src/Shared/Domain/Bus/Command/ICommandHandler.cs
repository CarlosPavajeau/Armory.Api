using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : Command
    {
        Task Handle(TCommand command);
    }
}
