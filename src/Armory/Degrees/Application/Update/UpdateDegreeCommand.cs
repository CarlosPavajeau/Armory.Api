using Armory.Shared.Domain.Bus.Command;

namespace Armory.Degrees.Application.Update
{
    public class UpdateDegreeCommand : Command
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
