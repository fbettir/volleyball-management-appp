using Microsoft.EntityFrameworkCore;

namespace VolleyballAPI.Entities
{
    [PrimaryKey(nameof(TournamentId), nameof(TeamId))]
    public class TournamentCompetitor
    {
        public Guid TournamentId { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
