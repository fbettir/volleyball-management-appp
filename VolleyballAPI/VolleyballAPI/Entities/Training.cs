using System.ComponentModel.DataAnnotations;
using VolleyballAPI.Enums;
using VolleyballAPI.JoinTableTypes;

namespace VolleyballAPI.Entities
{
    public class Training
  {
    [Required]
    [Key]
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public Guid LocationId { get; set; }
    public Guid CoachId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public PriceType AcceptableTickets { get; set; }
    public string PictureLink { get; set; }
    public virtual Team Team { get; set; } 
    public virtual Location Location { get; set; }
    public virtual User Coach{ get; set; }
    public virtual ICollection<TrainingParticipant> Players { get; set; } 
    public virtual ICollection<FavouriteTraining> UserHasAsFavourite { get; set; } 

  }
}
