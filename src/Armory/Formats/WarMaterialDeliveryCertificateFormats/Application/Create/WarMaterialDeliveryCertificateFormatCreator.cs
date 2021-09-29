using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;

namespace Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create
{
    public class WarMaterialDeliveryCertificateFormatCreator
    {
        private readonly IWarMaterialDeliveryCertificateFormatsRepository _repository;

        public WarMaterialDeliveryCertificateFormatCreator(IWarMaterialDeliveryCertificateFormatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarMaterialDeliveryCertificateFormat> Create(
            string code,
            DateTime validity,
            string place,
            DateTime date,
            string squadCode,
            string flightCode,
            string fireteamCode,
            string troopId,
            IEnumerable<string> weaponSerials,
            IDictionary<string, int> ammunition,
            IDictionary<string, int> equipments,
            IDictionary<string, int> explosives)
        {
            var format = WarMaterialDeliveryCertificateFormat.Create(
                code,
                validity,
                place,
                date,
                squadCode,
                flightCode,
                fireteamCode,
                troopId,
                weaponSerials,
                ammunition,
                equipments,
                explosives);

            await _repository.Save(format);

            return format;
        }
    }
}
