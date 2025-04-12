using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
{
    public class TrainingHeaderDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TeamHeaderDto Team { get; set; }
        public PriceType PriceType { get; set; }
    }
}
