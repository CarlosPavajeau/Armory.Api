using Armory.Api.Controllers.Squads.Requests;
using Armory.Squads.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class SquadsProfile : Profile
    {
        public SquadsProfile()
        {
            CreateMap<CreateSquadRequest, CreateSquadCommand>();
        }
    }
}
