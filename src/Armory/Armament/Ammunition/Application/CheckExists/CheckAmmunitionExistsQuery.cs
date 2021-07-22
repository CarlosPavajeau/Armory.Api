using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.CheckExists
{
    public class CheckAmmunitionExistsQuery : Query
    {
        public string Code { get; }

        public CheckAmmunitionExistsQuery(string code)
        {
            Code = code;
        }
    }
}
