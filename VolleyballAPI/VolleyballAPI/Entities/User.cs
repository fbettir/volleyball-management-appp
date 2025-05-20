using System.ComponentModel.DataAnnotations;
using VolleyballAPI.Enums;
using VolleyballAPI.JoinTableTypes;

namespace VolleyballAPI.Entities
{
    public class User
  {
    [Required]
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100), MinLength(5)]
    public string Name { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public int PlayerNumber { get; set; }
    public string PictureLink { get; set; }
    public Role Roles { get; set; }
    public PriceType PriceType { get; set; }
    public Gender Gender { get; set; }
    public Post Posts { get; set; }
    public virtual ICollection<Team> OwnedTeams { get; set; } 
    public virtual ICollection<TeamPlayer> JoinedTeams { get; set; } 
    public virtual ICollection<TrainingParticipant> Trainings { get; set; } 
    public virtual ICollection<TeamCoach> CoachedTeams { get; set; } 
    public virtual ICollection<FavouriteTeam> FavouriteTeams { get; set; }
    public virtual ICollection<FavouriteTraining> FavouriteTrainings { get; set; } 
    public virtual ICollection<FavouriteTournament> FavouriteTournaments { get; set; }


    }
}
