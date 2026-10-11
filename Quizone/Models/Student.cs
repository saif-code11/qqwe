using Microsoft.EntityFrameworkCore;

namespace Quizone.Models
{
    [Index(nameof(Name) , IsUnique = true)]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }

        public int CLassRoomId { get; set; }
        public ClassRoom? ClassRoom { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
