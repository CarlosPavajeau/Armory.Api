using Armory.Shared.Domain.Bus.Command;

namespace Armory.Troopers.Application.UpdateFireTeam
{
    public class UpdateTroopFireTeamCommand : Command
    {
        public string Id { get; init; }
        public string FireTeamCode { get; init; }
    }
}
