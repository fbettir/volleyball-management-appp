using System.ComponentModel.DataAnnotations;
using VolleyballAPI.Enums;
using VolleyballAPI.JoinTableTypes;

namespace VolleyballAPI.Entities
{
    public class Match
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public Guid RefereeId { get; set; }
        public Guid? TournamentId { get; set; } 
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public MatchState MatchState{ get; set; }
        public TournamentType? TournamentType { get; set; }

        public List<int> Points { get; set; } 
        public virtual Team Referee { get; set; }
        public virtual Location Location { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<MatchTeam> Teams { get; set; }

    }
}
