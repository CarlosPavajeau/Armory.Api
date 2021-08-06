using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.CheckExists
{
    public class CheckSquadExistsQuery : Query<bool>
    {
        public CheckSquadExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
