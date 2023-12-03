namespace VolleyballManagementAppBackend.Entities
{
  public class PlayerDetails
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public int PlayerNumber { get; set; }
  }
}
