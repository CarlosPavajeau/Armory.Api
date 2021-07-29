using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Explosives.Application.CheckExists
{
    public class CheckExplosiveExistsQuery : Query<bool>
    {
        public string Code { get; }

        public CheckExplosiveExistsQuery(string code)
        {
            Code = code;
        }
    }
}
