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
            CreateMap<Person, PersonResponse>();
            CreateMap<CreatePersonCommand, Person>();
        }
    }
}
