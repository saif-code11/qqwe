using System.ComponentModel.DataAnnotations;

namespace Quizone.Models
{
    public class Teacher
    {
        [Key]
       public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }          
        public string? PhoneNumber { get; set; }
        [Required, Range(0 , int.MaxValue)]
        public decimal Salary { get; set; }  
        
        public int DepatmentId { get; set; }

        public Department Department { get; set; }

        public List<Subject> Subjects { get; set; }


    }
}
