using System.ComponentModel.DataAnnotations;
using VolleyballAPI.JoinTableTypes;

namespace VolleyballAPI.Entities
{
    public class Team
  {
    [Required]
    [Key]
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    public Guid OwnerId { get; set; }
    [Required]
    [MaxLength(100), MinLength(5)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureLink { get; set; }

    public virtual User Owner { get; set; } 
    public virtual Location Location { get; set; }
    public virtual ICollection<TeamPlayer> Players { get; set; }  
    public virtual ICollection<TeamCoach> Coaches { get; set; } 
    public virtual ICollection<MatchTeam> Matches { get; set; } 
    public virtual ICollection<Training> Trainings { get; set; }
    public virtual ICollection<TournamentCompetitor> Tournaments { get; set; }
    public virtual ICollection<FavouriteTeam> UserHasAsFavourite { get; set; } 

    }
}
