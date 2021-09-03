using Armory.Degrees.Application;
using Armory.Degrees.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Degrees
{
    public class DegreesProfile : Profile
    {
        public DegreesProfile()
        {
            CreateMap<Degree, DegreeResponse>()
                .ForMember(d => d.RankName,
                    rankName => rankName.MapFrom(src => src.Rank == null ? string.Empty : src.Rank.Name));
        }
    }
}
