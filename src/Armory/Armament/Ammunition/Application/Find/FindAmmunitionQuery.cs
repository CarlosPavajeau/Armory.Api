using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.Find
{
    public class FindAmmunitionQuery : Query<AmmunitionResponse>
    {
        public FindAmmunitionQuery(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
