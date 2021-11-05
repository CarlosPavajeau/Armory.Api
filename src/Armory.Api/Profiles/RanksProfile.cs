using Armory.Api.Controllers.Ranks.Requests;
using Armory.Ranks.Application.Create;
using Armory.Ranks.Application.Update;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class RanksProfile : Profile
    {
        public RanksProfile()
        {
            CreateMap<CreateRankRequest, CreateRankCommand>();
            CreateMap<UpdateRankRequest, UpdateRankCommand>();
        }
    }
}
