using Armory.Api.Controllers.Flights.Requests;
using Armory.Flights.Application.Create;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class FlightsProfile : Profile
    {
        public FlightsProfile()
        {
            CreateMap<CreateFlightRequest, CreateFlightCommand>();
        }
    }
}
