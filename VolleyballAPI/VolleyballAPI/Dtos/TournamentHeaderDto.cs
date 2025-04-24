using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
{
    public class TournamentHeaderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EntryDeadline { get; set; }
        public LocationDto Location { get; set; }
        public string Organizer { get; set; }
        public string RegistrationPolicy { get; set; }
        public string TeamPolicy { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; } = null!;
        public Level Categories { get; set; }
        public PriceType PriceType { get; set; }
    }
}
