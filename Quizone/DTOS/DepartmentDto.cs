using System.ComponentModel.DataAnnotations;

namespace Quizone.DTOS
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
