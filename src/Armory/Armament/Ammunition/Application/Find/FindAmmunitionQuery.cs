using Armory.Shared.Domain.Bus.Query;

namespace Armory.Armament.Ammunition.Application.Find
{
    public class FindAmmunitionQuery : Query<AmmunitionResponse>
    {
        public FindAmmunitionQuery(string lot)
        {
            Lot = lot;
        }

        public string Lot { get; }
    }
}
