using Armory.Api.Controllers.Squadron.Requests;
using Armory.Squadrons.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class SquadronsProfile : Profile
    {
        public SquadronsProfile()
        {
            CreateMap<CreateSquadronRequest, CreateSquadronCommand>();
        }
    }
}
