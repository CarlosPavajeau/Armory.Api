using Armory.Api.Controllers.Squads.Requests;
using Armory.Squads.Application.Create;
using Armory.Squads.UpdateCommander;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class SquadsProfile : Profile
    {
        public SquadsProfile()
        {
            CreateMap<CreateSquadRequest, CreateSquadCommand>();
            CreateMap<UpdateSquadCommanderRequest, UpdateSquadCommanderCommand>();
        }
    }
}
