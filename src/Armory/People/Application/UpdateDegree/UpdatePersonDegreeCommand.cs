using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.UpdateDegree
{
    public class UpdatePersonDegreeCommand : Command
    {
        public string Id { get; init; }
        public int DegreeId { get; init; }
    }
}
