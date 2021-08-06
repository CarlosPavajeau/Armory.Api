using Armory.Armament.Explosives.Domain;

namespace Armory.Armament.Explosives.Application
{
    public class ExplosiveResponse
    {
        public ExplosiveResponse(string code, string type, string caliber, string mark, string lot, string series,
            int quantityAvailable)
        {
            Code = code;
            Type = type;
            Caliber = caliber;
            Mark = mark;
            Lot = lot;
            Series = series;
            QuantityAvailable = quantityAvailable;
        }

        public string Code { get; }
        public string Type { get; }
        public string Caliber { get; }
        public string Mark { get; }
        public string Lot { get; }
        public string Series { get; }
        public int QuantityAvailable { get; }

        public static ExplosiveResponse FromAggregate(Explosive explosive)
        {
            return new ExplosiveResponse(explosive.Code, explosive.Type, explosive.Caliber, explosive.Mark,
                explosive.Lot,
                explosive.Series, explosive.QuantityAvailable);
        }
    }
}
