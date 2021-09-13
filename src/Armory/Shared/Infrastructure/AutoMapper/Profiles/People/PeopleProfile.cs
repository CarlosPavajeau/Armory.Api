using Armory.People.Application;
using Armory.People.Application.Create;
using Armory.People.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.People
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<Person, PersonResponse>()
                .ForMember(p => p.RankName,
                    rankName => rankName.MapFrom(src =>
                        src.Degree == null || src.Degree.Rank == null ? string.Empty : src.Degree.Rank.Name))
                .ForMember(p => p.DegreeName,
                    degreeName => degreeName.MapFrom(src => src.Degree == null ? string.Empty : src.Degree.Name));
            CreateMap<CreatePersonCommand, Person>();
        }
    }
}
