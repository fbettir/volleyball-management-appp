using VolleyballAPI.Enums;

namespace VolleyballAPI.Dtos.UserDtos
{
    public class EditUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public int PlayerNumber { get; set; }
        public string PictureLink { get; set; } = null!;
        public Role Roles { get; set; }
        public PriceType PriceType { get; set; }
        public Gender Gender { get; set; }
        public Post Posts { get; set; }
    }
}
