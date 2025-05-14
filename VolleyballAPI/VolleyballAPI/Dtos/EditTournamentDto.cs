using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
{
    public class RegisterTournamentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime EntryDeadline { get; set; }
        public Guid LocationId { get; set; }
        public string Organizer { get; set; }
        public string RegistrationPolicy { get; set; }
        public string TeamPolicy { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; set; } = null!;
        public TournamentType TournamentType { get; set; }
        public int Courts { get; set; }
        public List<int> MaxTeamsPerLevel { get; set; }
        public Level Categories { get; set; }
        public PriceType PriceType { get; set; }
    }
}
