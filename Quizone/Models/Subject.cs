using System.ComponentModel.DataAnnotations;

namespace Quizone.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set;}

        [Required]
        [Range(1,100)]
        public int MaxGrade { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Enrollment> Enrollments { get; set; }

    }
}
