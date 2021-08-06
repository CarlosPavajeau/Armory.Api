using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.CheckExists
{
    public class CheckSquadronExistsQuery : Query<bool>
    {
        public CheckSquadronExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
