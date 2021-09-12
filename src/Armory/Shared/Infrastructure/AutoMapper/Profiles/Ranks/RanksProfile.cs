using Armory.Ranks.Application;
using Armory.Ranks.Application.Create;
using Armory.Ranks.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Ranks
{
    public class RanksProfile : Profile
    {
        public RanksProfile()
        {
            CreateMap<Rank, RankResponse>();
            CreateMap<CreateRankCommand, Rank>();
        }
    }
}
