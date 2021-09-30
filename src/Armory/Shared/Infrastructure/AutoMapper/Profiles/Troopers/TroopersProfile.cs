using Armory.Troopers.Application;
using Armory.Troopers.Application.Create;
using Armory.Troopers.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Troopers
{
    public class TroopersProfile : Profile
    {
        public TroopersProfile()
        {
            CreateMap<Troop, TroopResponse>()
                .ForMember(t => t.FireteamName,
                    fireteamName =>
                        fireteamName.MapFrom(src =>
                            src.Fireteam == null ? string.Empty : $"{src.FireteamCode} - {src.Fireteam.Name}"))
                .ForMember(t => t.RankName,
                    rankName => rankName.MapFrom(src =>
                        src.Degree == null ? string.Empty :
                        src.Degree.Rank == null ? string.Empty : src.Degree.Rank.Name))
                .ForMember(t => t.DegreeName,
                    degreeName => degreeName.MapFrom(src => src.Degree == null ? string.Empty : src.Degree.Name));
            CreateMap<CreateTroopCommand, Troop>();
        }
    }
}
