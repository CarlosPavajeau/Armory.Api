using Armory.Flights.Application;
using Armory.Flights.Application.Create;
using Armory.Flights.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Flights
{
    public class FlightsProfile : Profile
    {
        public FlightsProfile()
        {
            CreateMap<Flight, FlightResponse>()
                .ForMember(s => s.OwnerName,
                    ownerName => ownerName.MapFrom(src =>
                        src.Commander == null
                            ? string.Empty
                            : $"{src.Commander.Degree.Name} - {src.Commander.FullName}"));
            CreateMap<CreateFlightCommand, Flight>();
        }
    }
}
