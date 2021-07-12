using Armory.Api.Controllers.Ranks.Requests;
using Armory.Ranks.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class RanksProfile : Profile
    {
        public RanksProfile()
        {
            CreateMap<CreateRankRequest, CreateRankCommand>();
        }
    }
}
