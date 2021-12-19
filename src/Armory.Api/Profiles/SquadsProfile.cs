using Armory.Api.Controllers.Squads.Requests;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.Update;
using Armory.Squads.Application.UpdateCommander;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class SquadsProfile : Profile
    {
        public SquadsProfile()
        {
            CreateMap<CreateSquadRequest, CreateSquadCommand>();
            CreateMap<UpdateSquadCommanderRequest, UpdateSquadCommanderCommand>();
            CreateMap<UpdateSquadRequest, UpdateSquadCommand>();
        }
    }
}
