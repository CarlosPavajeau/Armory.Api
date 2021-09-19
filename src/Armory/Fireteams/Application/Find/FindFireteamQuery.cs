using Armory.Shared.Domain.Bus.Query;

namespace Armory.Fireteams.Application.Find
{
    public class FindFireteamQuery : Query<FireteamResponse>
    {
        public FindFireteamQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
