using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Delete
{
    public class DeletePersonCommand : Command
    {
        public DeletePersonCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
