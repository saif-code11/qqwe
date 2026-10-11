using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizone.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public DateTime EnrollmentTime { get; set; }

        [Range(0,100)]
        public decimal Grade { get; set; }


    }
}
