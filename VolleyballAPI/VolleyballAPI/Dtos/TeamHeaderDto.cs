namespace VolleyballAPI.Dtos
{
    public class TeamHeaderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureLink { get; set; } = null!;

    }
}
