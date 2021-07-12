using Armory.Api.Controllers.People.Requests;
using Armory.People.Application.Create;
using Armory.People.Application.Update;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<CreatePersonRequest, CreatePersonCommand>();
            CreateMap<UpdatePersonRequest, UpdatePersonCommand>();
        }
    }
}
