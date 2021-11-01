using Armory.Api.Controllers.Fireteams.Requests;
using Armory.Fireteams.Application.Create;
using Armory.Fireteams.Application.UpdateCommander;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class FireteamsProfile : Profile
    {
        public FireteamsProfile()
        {
            CreateMap<CreateFireteamRequest, CreateFireteamCommand>();
            CreateMap<UpdateFireTeamCommanderRequest, UpdateFireTeamCommanderCommand>();
        }
    }
}
