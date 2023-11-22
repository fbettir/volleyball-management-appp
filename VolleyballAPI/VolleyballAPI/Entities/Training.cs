using System.ComponentModel.DataAnnotations;
using VolleyballAPI.Entities;

namespace VolleyballManagementAppBackend.Entities
{
  public class Training
  {
    [Key]
    public Guid Id { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public virtual ICollection<TrainingParticipant> Players { get; set; }

    }
}
