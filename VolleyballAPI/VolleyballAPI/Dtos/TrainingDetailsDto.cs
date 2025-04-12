using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
{
    public class TrainingDetailsDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TeamHeaderDto Team { get; set; }
        public PriceType PriceType { get; set; }
        public List<UserHeaderDto> Players { get; set; }
        public List<UserHeaderDto> UserHasAsFavourite { get; set; }
    }
}
