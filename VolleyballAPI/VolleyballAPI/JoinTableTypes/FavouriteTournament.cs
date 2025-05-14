using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;

namespace VolleyballAPI.JoinTableTypes
{
    [PrimaryKey(nameof(TournamentId), nameof(UserId))]
    public class FavouriteTournament
    {
        public Guid TournamentId { get; set; }
        public Guid UserId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual User User { get; set; }
    }
}
