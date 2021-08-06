using Armory.Shared.Domain.Bus.Command;

namespace Armory.Ranks.Application.Create
{
    public class CreateRankCommand : Command
    {
        public CreateRankCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
