using System.Threading.Tasks;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework;
using AutoMapper;

namespace Armory.Armament.Explosives.Application.Update
{
    public class ExplosiveUpdater
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public ExplosiveUpdater(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task Update(Explosive explosive, UpdateExplosiveCommand command)
        {
            _mapper.Map(explosive, command);
            await _unitWork.SaveChanges();
        }
    }
}
