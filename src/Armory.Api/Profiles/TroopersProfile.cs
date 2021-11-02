using Armory.Api.Controllers.Troopers.Requests;
using Armory.Troopers.Application.Create;
using Armory.Troopers.Application.Update;
using Armory.Troopers.Application.UpdateFireTeam;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class TroopersProfile : Profile
    {
        public TroopersProfile()
        {
            CreateMap<CreateTroopRequest, CreateTroopCommand>();
            CreateMap<UpdateTroopRequest, UpdateTroopCommand>();
            CreateMap<UpdateTroopFireTeamRequest, UpdateTroopFireTeamCommand>();
        }
    }
}
