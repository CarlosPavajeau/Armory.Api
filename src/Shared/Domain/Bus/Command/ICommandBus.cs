using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Command
{
    public interface ICommandBus
    {
        Task Dispatch(Command command);
    }
}
