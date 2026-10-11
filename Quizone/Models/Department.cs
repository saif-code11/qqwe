using System.ComponentModel.DataAnnotations;

namespace Quizone.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
