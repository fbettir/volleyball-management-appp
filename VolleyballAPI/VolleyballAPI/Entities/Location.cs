using System.ComponentModel.DataAnnotations;

namespace VolleyballAPI.Entities
{
    public class Location
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
