using VolleyballAPI.Entities;

namespace VolleyballAPI.Dtos
{
    public class UserHeaderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string PictureLink { get; set; } 
        public int PlayerNumber { get; set; }
        public Role Roles { get; set; }
        public PriceType PriceType { get; set; }
        public Gender Gender { get; set; }
        public Post Posts { get; set; }
    }
}
