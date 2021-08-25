using Armory.Troopers.Application;
using Armory.Troopers.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Troopers
{
    public class TroopersProfile : Profile
    {
        public TroopersProfile()
        {
            CreateMap<Troop, TroopResponse>();
        }
    }
}
