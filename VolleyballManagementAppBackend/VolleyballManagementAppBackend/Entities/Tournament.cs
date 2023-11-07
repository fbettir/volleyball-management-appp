namespace VolleyballManagementAppBackend.Entities
{
  public class Tournament
  {
    public string Id { get; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
  }
}
