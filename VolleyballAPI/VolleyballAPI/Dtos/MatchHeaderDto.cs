namespace VolleyballAPI.Dtos
{
    public class MatchHeaderDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public TournamentHeaderDto Tournament { get; set; }
        public TeamHeaderDto Referee { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
    }
}
