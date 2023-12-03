namespace VolleyballManagementAppBackend.Entities
{
  public class Team
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public string Description { get; set; }

    public virtual ICollection<TeamPlayer> Players { get; set; }  //lazy loading
    public virtual ICollection<User> Coaches { get; set; }  //lazy loading
  }
}
