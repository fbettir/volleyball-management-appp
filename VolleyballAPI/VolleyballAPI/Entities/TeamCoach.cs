using Microsoft.EntityFrameworkCore;

namespace VolleyballManagementAppBackend.Entities
{
    [PrimaryKey(nameof(TeamId), nameof(UserId))]
    public class TeamCoach
    {
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }

        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
    }
}
