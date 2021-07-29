using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.CheckExists
{
    public class CheckSquadronExistsQuery : Query<bool>
    {
        public string Code { get; }

        public CheckSquadronExistsQuery(string code)
        {
            Code = code;
        }
    }
}
