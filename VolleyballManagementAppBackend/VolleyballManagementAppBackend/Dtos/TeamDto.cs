namespace VolleyballManagementAppBackend.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
