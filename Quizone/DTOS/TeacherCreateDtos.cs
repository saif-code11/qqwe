using System.ComponentModel.DataAnnotations;

namespace Quizone.DTOS
{
    public class TeacherCreateDtos
    {
        [Required]
        [MaxLength(50)]
   
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        [Required, Range(0, int.MaxValue)]
        public decimal Salary { get; set; }

        public int Dpid { get; set; }

    }
}
