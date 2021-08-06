using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Update
{
    public class UpdateExplosiveCommand : Command
    {
        public UpdateExplosiveCommand(string code, string type, string caliber, string mark, string lot, string series,
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
    }
}
