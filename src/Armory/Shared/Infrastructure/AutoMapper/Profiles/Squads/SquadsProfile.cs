using Armory.Squads.Application;
using Armory.Squads.Application.Create;
using Armory.Squads.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Squads
{
    public class SquadsProfile : Profile
    {
        public SquadsProfile()
        {
            CreateMap<CreateSquadCommand, Squad>();
            CreateMap<Squad, SquadResponse>();
        }
    }
}
