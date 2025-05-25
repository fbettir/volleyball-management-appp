using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.MatchDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.TournamentDtos;
using VolleyballAPI.Dtos.TrainingDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Entities;

namespace VolleyballAPI
{
    public class Profile : AutoMapper.Profile
    {
        public Profile() 
        {
            CreateMap<Location, LocationDto>().ReverseMap();
            
            CreateMap<TournamentHeaderDto, Tournament>().ReverseMap();
            CreateMap<EditTournamentDto, Tournament>().ReverseMap();
            CreateMap<EditTournamentDto, TournamentDetailsDto>().ReverseMap();

            CreateMap<Team, TeamHeaderDto>().ReverseMap();
            CreateMap<EditTeamDto, Team>().ReverseMap();
            CreateMap<EditTeamDto, TeamDetailsDto>().ReverseMap();

            CreateMap<Training, TrainingHeaderDto>().ReverseMap();
            CreateMap<EditTrainingDto, Training>().ReverseMap();
            CreateMap<EditTrainingDto, TrainingDetailsDto>().ReverseMap();

            CreateMap<User, UserHeaderDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<EditUserDto, User>().ReverseMap();
            CreateMap<EditUserDto, UserDetailsDto>().ReverseMap();

            CreateMap<Match, MatchHeaderDto>()
                .ForMember(dto => dto.Teams, opt => opt.MapFrom(m => m.Teams.Select(mt => mt.Team)))
                .ReverseMap();

            CreateMap<User, Auth0UserDto>()
                .ForMember(dto => dto.Auth0Id, opt => opt.MapFrom(u => u.Auth0Id))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(u => u.Name));

            CreateMap<User, UserDetailsDto>()
                .ForMember(dto => dto.JoinedTeams, opt => opt.MapFrom(u => u.JoinedTeams.Select(tp => tp.Team)))
                .ForMember(dto => dto.CoachedTeams, opt => opt.MapFrom(u => u.CoachedTeams.Select(tc => tc.Team)))
                .ForMember(dto => dto.Trainings, opt => opt.MapFrom(u => u.Trainings.Select(tp => tp.Training)))
                .ForMember(dto => dto.FavouriteTeams, opt => opt.MapFrom(u => u.FavouriteTeams.Select(ft => ft.Team)))
                .ForMember(dto => dto.FavouriteTournaments, opt => opt.MapFrom(u => u.FavouriteTournaments.Select(ft => ft.Tournament)))
                .ForMember(dto => dto.FavouriteTrainings, opt => opt.MapFrom(u => u.FavouriteTrainings.Select(ft => ft.Training)))
                .ReverseMap();

            CreateMap<Training, TrainingDetailsDto>()
                .ForMember(dto => dto.Players, opt => opt.MapFrom(t => t.Players.Select(tp => tp.User)))
                .ForMember(dto => dto.UserHasAsFavourite, opt => opt.MapFrom(t => t.UserHasAsFavourite.Select(ft => ft.User)))
                .ReverseMap();

            CreateMap<Tournament, TournamentDetailsDto>()
                .ForMember(dto => dto.Teams, opt => opt.MapFrom(t => t.Teams.Select(tc => tc.Team)))
                .ForMember(dto => dto.UserHasAsFavourite, opt => opt.MapFrom(t => t.UserHasAsFavourite.Select(ft => ft.User)))
                .ReverseMap();

            CreateMap<Match, MatchDetailsDto>()
                .ForMember(dto => dto.Teams, opt => opt.MapFrom(m => m.Teams.Select(mt => mt.Team)))
                .ReverseMap();

            CreateMap<Team, TeamDetailsDto>()
                .ForMember(dto => dto.Players, opt => opt.MapFrom(t => t.Players.Select(tp => tp.User)))
                .ForMember(dto => dto.Coaches, opt => opt.MapFrom(t => t.Coaches.Select(tc => tc.User)))
                .ForMember(dto => dto.Matches, opt => opt.MapFrom(t => t.Matches.Select(mt => mt.Match)))
                .ForMember(dto => dto.Tournaments, opt => opt.MapFrom(t => t.Tournaments.Select(tc => tc.Tournament)))
                .ForMember(dto => dto.UserHasAsFavourite, opt => opt.MapFrom(t => t.UserHasAsFavourite.Select(mt => mt.User)))
                .ReverseMap();

        }
    }
}
