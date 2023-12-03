namespace VolleyballManagementAppBackend.Entities
{
    public class TeamCoach
    {
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }

        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
    }
}
