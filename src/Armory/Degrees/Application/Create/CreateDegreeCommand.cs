using Armory.Shared.Domain.Bus.Command;

namespace Armory.Degrees.Application.Create
{
    public class CreateDegreeCommand : Command
    {
        public CreateDegreeCommand(string name, int rankId)
        {
            Name = name;
            RankId = rankId;
        }

        public string Name { get; }
        public int RankId { get; }
    }
}
