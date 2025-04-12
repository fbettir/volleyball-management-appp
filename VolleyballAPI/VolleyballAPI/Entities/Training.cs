using System.ComponentModel.DataAnnotations;

namespace VolleyballAPI.Entities
{
  public class Training
  {
    [Required]
    [Key]
    public Guid Id { get; set; }
    public Guid TeamId { get; set; } //done
    public Guid LocationId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public PriceType AcceptableTickets { get; set; }

    public virtual Team Team { get; set; } 
    public virtual Location Location { get; set; }
    public virtual ICollection<TrainingParticipant> Players { get; set; } 
    public virtual ICollection<FavouriteTraining> UserHasAsFavourite { get; set; } 

  }
}
