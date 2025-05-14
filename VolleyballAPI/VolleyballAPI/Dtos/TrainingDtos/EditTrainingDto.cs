using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.TrainingDtos
{
    public class EditTrainingDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TeamHeaderDto Team { get; set; }
        public PriceType PriceType { get; set; }
        public string PictureLink { get; set; } = null!;
    }
}
