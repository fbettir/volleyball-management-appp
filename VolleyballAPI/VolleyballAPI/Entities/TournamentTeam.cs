using VolleyballManagementAppBackend.Entities;

namespace VolleyballAPI.Entities
{
    public class TournamentTeam
    {
        public Guid TournamentId { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
