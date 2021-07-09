namespace Armory.Armament.Ammunition.Application
{
    public class AmmunitionResponse
    {
        public string Code { get; }
        public string Type { get; }
        public string Mark { get; }
        public string Caliber { get; }
        public string Series { get; }
        public string Lot { get; }
        public int QuantityAvailable { get; }

        public AmmunitionResponse(string code, string type, string mark, string caliber, string series, string lot,
            int quantityAvailable)
        {
            Code = code;
            Type = type;
            Mark = mark;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            QuantityAvailable = quantityAvailable;
        }

        public static AmmunitionResponse FromAggregate(Domain.Ammunition ammunition)
        {
            return new(ammunition.Code, ammunition.Type, ammunition.Mark, ammunition.Caliber, ammunition.Series,
                ammunition.Lot, ammunition.QuantityAvailable);
        }
    }
}
