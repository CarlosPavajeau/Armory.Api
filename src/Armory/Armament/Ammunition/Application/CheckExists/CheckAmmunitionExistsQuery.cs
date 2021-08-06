using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.CheckExists
{
    public class CheckAmmunitionExistsQuery : Query<bool>
    {
        public CheckAmmunitionExistsQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
