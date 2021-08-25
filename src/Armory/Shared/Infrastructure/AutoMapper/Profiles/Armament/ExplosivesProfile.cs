using Armory.Armament.Explosives.Application;
using Armory.Armament.Explosives.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Armament
{
    public class ExplosivesProfile : Profile
    {
        public ExplosivesProfile()
        {
            CreateMap<Explosive, ExplosiveResponse>();
        }
    }
}
