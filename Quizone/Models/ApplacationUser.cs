using System.ComponentModel.DataAnnotations;

namespace Quizone.Models
{
    public class ApplacationUser
    {
        public int Id { get; set; }
        [Required , MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(150) , EmailAddress]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; } = "Student";
    }
}
