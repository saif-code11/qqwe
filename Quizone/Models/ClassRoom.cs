using System.ComponentModel.DataAnnotations;

namespace Quizone.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1,12)]
        public int GradeLevel { get; set; }
        public int Capacity { get; set; }
        public List<Student> students { get; set; }


    }
}
