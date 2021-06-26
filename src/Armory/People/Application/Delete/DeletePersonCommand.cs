using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Delete
{
    public class DeletePersonCommand : Command
    {
        public string Id { get; }

        public DeletePersonCommand(string id)
        {
            Id = id;
        }
    }
}
