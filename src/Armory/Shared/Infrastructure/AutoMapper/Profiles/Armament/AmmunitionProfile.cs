using Armory.Armament.Ammunition.Application;
using Armory.Armament.Ammunition.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Armament
{
    public class AmmunitionProfile : Profile
    {
        public AmmunitionProfile()
        {
            CreateMap<Ammunition, AmmunitionResponse>();
        }
    }
}
