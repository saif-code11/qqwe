using Quizone.Models;
using System.ComponentModel.DataAnnotations;

namespace Quizone.DTOS
{
    public class TeacherDtos
    {
        public int Id { get; set; }
   
        public string FullName { get; set; }
        
      
      
       
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        public decimal Salary { get; set; }
        public string Departmentname { get; set; }
    }
}
