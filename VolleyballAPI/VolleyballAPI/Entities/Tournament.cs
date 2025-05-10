using System.ComponentModel.DataAnnotations;

namespace VolleyballAPI.Entities
{
  public class Tournament
  {
    [Required]
    [Key]
    public Guid Id { get; set; }
    public Guid LocationId { get; set; }
    [Required]
    [MaxLength(100), MinLength(5)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public DateTime EntryDeadline { get; set; }
    public string Organizer { get; set; }
    public string RegistrationPolicy { get; set; }
    public string TeamPolicy { get; set; }
    public int Courts{ get; set; }
    public List<int> MaxTeamsPerLevel{ get; set; }
    public string Description { get; set; }
    public string PictureLink { get; set; }
    public Level Categories { get; set; }
    public PriceType PriceType { get; set; }
    public TournamentType TournamentType{ get; set; }


    public virtual Location Location { get; set; }
    public virtual ICollection<TournamentCompetitor> Teams { get; set; }
    public virtual ICollection<Match> Matches { get; set; }
    public virtual ICollection<FavouriteTournament> UserHasAsFavourite { get; set; }
    }
}
