using System.ComponentModel.DataAnnotations;
using VolleyballAPI.Entities;

namespace VolleyballManagementAppBackend.Entities
{
    
  public class Team
  {
    [Required]
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100), MinLength(5)]
    public string Name { get; set; }
    public string Picture { get; set; }
    public string Description { get; set; }

    public virtual ICollection<TeamPlayer> Players { get; set; }  //lazy loading
    public virtual ICollection<TeamCoach> Coaches { get; set; }
    public virtual ICollection<Training> Trainings { get; set; }
    public virtual ICollection<TournamentCompetitor> Tournaments { get; set; }  

    }
}
