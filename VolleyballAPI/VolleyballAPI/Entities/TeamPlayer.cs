using Microsoft.EntityFrameworkCore;

namespace VolleyballManagementAppBackend.Entities
{
    [PrimaryKey(nameof(TeamId), nameof(PlayerId))]
    public class TeamPlayer
    {
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }

        public virtual Team Team { get; set; }
        public virtual PlayerDetails Player { get; set; }
    }
}
