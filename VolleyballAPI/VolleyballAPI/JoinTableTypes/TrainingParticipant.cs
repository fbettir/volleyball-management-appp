using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;

namespace VolleyballAPI.JoinTableTypes
{
    [PrimaryKey(nameof(UserId), nameof(TrainingId))]
    public class TrainingParticipant
    {
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }

        public virtual Training Training { get; set; }
        public virtual User User { get; set; }

    }
}
