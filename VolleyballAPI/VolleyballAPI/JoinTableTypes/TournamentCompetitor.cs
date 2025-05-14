using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;

namespace VolleyballAPI.JoinTableTypes
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
