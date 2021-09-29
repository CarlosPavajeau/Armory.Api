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
                        src.Owner == null ? string.Empty : $"{src.Owner.Degree.Name} - {src.Owner.FullName}"));
            CreateMap<CreateFlightCommand, Flight>();
        }
    }
}
