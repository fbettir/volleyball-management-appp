using VolleyballAPI.Dtos.LocationDtos;
using VolleyballAPI.Dtos.UserDtos;

namespace VolleyballAPI.Dtos.TeamDtos
{
    public class EditTeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureLink { get; set; } = null!;
        public LocationDto Location { get; set; }
        public UserDto Owner {  get; set; } 
    }
}
