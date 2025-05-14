using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;
using VolleyballAPI.Enums;

namespace VolleyballAPI.JoinTableTypes
{
    [PrimaryKey(nameof(MatchId), nameof(TeamId))]
    public class MatchTeam
    {
        public Guid MatchId { get; set; }
        public Guid TeamId { get; set; }

        public virtual Match Match { get; set; }
        public virtual Team Team { get; set; }
    }
}
