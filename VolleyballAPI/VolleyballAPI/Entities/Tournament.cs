using System.ComponentModel.DataAnnotations;
using VolleyballAPI.Entities;

namespace VolleyballManagementAppBackend.Entities
{
  public class Tournament
  {
    [Required]
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100), MinLength(5)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public virtual ICollection<TournamentCompetitor> Teams { get; set; }  //lazy loading

    }
}
