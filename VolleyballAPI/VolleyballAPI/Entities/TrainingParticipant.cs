using Microsoft.EntityFrameworkCore;
using VolleyballManagementAppBackend.Entities;

namespace VolleyballAPI.Entities
{
    [PrimaryKey(nameof(PlayerDetailsId), nameof(TrainingId))]
    public class TrainingParticipant
    {
        public Guid TrainingId { get; set; }
        public Guid PlayerDetailsId { get; set; }

        public virtual Training Training { get; set; }
        public virtual PlayerDetails PlayerDetails { get; set; }

    }
}
