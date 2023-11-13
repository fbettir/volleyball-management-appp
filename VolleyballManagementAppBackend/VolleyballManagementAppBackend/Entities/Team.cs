namespace VolleyballManagementAppBackend.Entities
{
  public class Team
  {
    public Team() { }
    public Team(int id) {
        Id = id;
    }
    public Team(int id, string name, string picture, string description) : this(id)
    {
        Name = name;
        Picture = picture;
        Description = description;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Picture { get; set; } = null!;
    public string Description { get; set; } = null!;
  }
}
