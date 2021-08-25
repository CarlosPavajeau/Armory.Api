using Armory.Squads.Application;
using Armory.Squads.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Squads
{
    public class SquadsProfile : Profile
    {
        public SquadsProfile()
        {
            CreateMap<Squad, SquadResponse>();
        }
    }
}
