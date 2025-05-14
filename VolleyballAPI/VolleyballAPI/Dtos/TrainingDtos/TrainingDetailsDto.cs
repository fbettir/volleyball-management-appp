using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.TeamDtos;
using VolleyballAPI.Dtos.UserDtos;
using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.TrainingDtos
{
    public class TrainingDetailsDto
    {
        public Guid Id { get; set; }
        public LocationDto Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TeamHeaderDto Team { get; set; }
        public PriceType PriceType { get; set; }
        public string PictureLink { get; set; } = null!;
        public List<UserHeaderDto> Players { get; set; }
        public List<UserHeaderDto> UserHasAsFavourite { get; set; }
    }
}
