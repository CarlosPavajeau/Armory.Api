using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Armament.Equipments.Domain;

namespace Armory.Armament.Equipments.Application.SearchAll
{
    public class AllEquipmentsSearcher
    {
        private readonly IEquipmentsRepository _repository;

        public AllEquipmentsSearcher(IEquipmentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Equipment>> SearchAll()
        {
            return await _repository.SearchAll();
        }
    }
}
