namespace VolleyballAPI.Dtos.UserDtos
{
    public class Auth0UserDto
    {
        public string Auth0Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Name { get; set; }
        public string? PictureLink { get; set; }
    }
}
