using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.CheckExists
{
    public class CheckSquadExistsQuery : Query<bool>
    {
        public string Code { get; }

        public CheckSquadExistsQuery(string code)
        {
            Code = code;
        }
    }
}
