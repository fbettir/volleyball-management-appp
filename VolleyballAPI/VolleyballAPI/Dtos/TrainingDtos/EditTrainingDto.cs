using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.TrainingDtos
{
    public class EditTrainingDto
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid TeamId { get; set; }
        public Guid CoachId { get; set; }
        public PriceType PriceType { get; set; }
        public string PictureLink { get; set; } = null!;
    }
}
