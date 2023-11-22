using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VolleyballAPI.Entities;

namespace VolleyballManagementAppBackend.Entities
{
  public class PlayerDetails
  {
    [Required]
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public int PlayerNumber { get; set; }
    public TicketPass TicketPass { get; set; }
    public Gender Gender { get; set; }
    public ICollection<Post> Posts { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<TeamPlayer> Teams { get; set; }

    }
}
