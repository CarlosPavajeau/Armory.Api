using Armory.Shared.Domain.Bus.Query;

namespace Armory.Fireteams.Application.CheckExists
{
    public class CheckFireteamExistsQuery : Query<bool>
    {
        public CheckFireteamExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
