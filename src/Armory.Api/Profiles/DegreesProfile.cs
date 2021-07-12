using Armory.Api.Controllers.Degrees.Requests;
using Armory.Degrees.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class DegreesProfile : Profile
    {
        public DegreesProfile()
        {
            CreateMap<CreateDegreeRequest, CreateDegreeCommand>();
        }
    }
}
