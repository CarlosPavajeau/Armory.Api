using Armory.Fireteams.Application;
using Armory.Fireteams.Application.Create;
using Armory.Fireteams.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Fireteams
{
    public class FireteamsProfile : Profile
    {
        public FireteamsProfile()
        {
            CreateMap<Fireteam, FireteamResponse>()
                .ForMember(s => s.FlightName,
                    flightName =>
                        flightName.MapFrom(src =>
                            src.Flight == null ? string.Empty : $"{src.FlightCode} - {src.Flight.Name}"))
                .ForMember(s => s.OwnerName,
                    ownerName => ownerName.MapFrom(src =>
                        src.Owner == null
                            ? string.Empty
                            : $"{src.Owner.Degree.Name} - {src.Owner.FullName}"));
            CreateMap<CreateFireteamCommand, Fireteam>();
        }
    }
}
