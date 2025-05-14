using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;

namespace VolleyballAPI.JoinTableTypes
{
    [PrimaryKey(nameof(TeamId), nameof(UserId))]
    public class FavouriteTeam
    {
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }
        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
    }
}
