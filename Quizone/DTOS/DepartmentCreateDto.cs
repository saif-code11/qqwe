using System.ComponentModel.DataAnnotations;

namespace Quizone.DTOS
{
    public class DepartmentCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
