using Armory.Shared.Domain.Bus.Command;

namespace Armory.Ranks.Application.Create
{
    public class CreateRankCommand : Command
    {
        public string Name { get; }

        public CreateRankCommand(string name)
        {
            Name = name;
        }
    }
}
