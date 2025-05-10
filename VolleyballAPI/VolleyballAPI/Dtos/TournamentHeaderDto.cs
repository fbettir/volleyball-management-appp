using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
{
    public class TournamentHeaderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public LocationDto Location { get; set; }

    }
}
