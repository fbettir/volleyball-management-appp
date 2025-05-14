using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.UserDtos
{
    public class UserHeaderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Post Posts { get; set; }
        public string PictureLink { get; set; } = null!;
    }
}
