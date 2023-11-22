using System.ComponentModel.DataAnnotations;

namespace VolleyballManagementAppBackend.Entities
{
  public class User
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100), MinLength(5)]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual ICollection<Role> Roles { get; set; }  //lazy loading
  }
}
