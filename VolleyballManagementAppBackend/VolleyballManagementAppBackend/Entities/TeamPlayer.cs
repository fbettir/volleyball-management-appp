namespace VolleyballManagementAppBackend.Entities
{
    public class TeamPlayer
    {
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }

        public virtual Team Team { get; set; }
        public virtual PlayerDetails Player { get; set; }
    }
}
