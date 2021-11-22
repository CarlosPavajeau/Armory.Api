using System.Threading.Tasks;
using Armory.Shared.Domain.Persistence.EntityFramework;
using AutoMapper;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class AmmunitionUpdater
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public AmmunitionUpdater(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task Update(Domain.Ammunition ammunition, UpdateAmmunitionCommand command)
        {
            _mapper.Map(command, ammunition);
            await _unitWork.SaveChanges();
        }
    }
}
