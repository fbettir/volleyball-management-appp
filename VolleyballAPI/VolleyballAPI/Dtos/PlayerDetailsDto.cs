using System.ComponentModel.DataAnnotations;
using VolleyballManagementAppBackend.Entities;

namespace VolleyballAPI.Dtos
{
    public class PlayerDetailsDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public int PlayerNumber { get; set; }
        public TicketPass TicketPass { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
