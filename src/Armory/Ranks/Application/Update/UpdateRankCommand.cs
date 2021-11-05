using Armory.Shared.Domain.Bus.Command;

namespace Armory.Ranks.Application.Update
{
    public class UpdateRankCommand : Command
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
