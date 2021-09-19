using Armory.Api.Controllers.Fireteams.Requests;
using Armory.Fireteams.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class FireteamsProfile : Profile
    {
        public FireteamsProfile()
        {
            CreateMap<CreateFireteamRequest, CreateFireteamCommand>();
        }
    }
}
