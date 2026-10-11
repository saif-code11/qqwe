using Microsoft.AspNetCore.Mvc;
using Quizone.Models;

namespace Quizone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        protected readonly AppDbContext _appDbContext;

        public StudentController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _appDbContext.students.ToList();

            if (!data.Any())
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var data = _appDbContext.students
                .FirstOrDefault(e => e.Id == id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("name/{name}")]
        public ActionResult GetByName(string name)
        {
            var data = _appDbContext.students
                .FirstOrDefault(e => e.Name == name);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("firstname/{firstname}")]
        public ActionResult GetByFirstName(string firstname)
        {
            var data = _appDbContext.students
                .FirstOrDefault(e => e.FirstName == firstname);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("email/{email}")]
        public ActionResult GetByEmail(string email)
        {
            var data = _appDbContext.students
                .FirstOrDefault(e => e.Email == email);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Post(Student student)
        {
            if (student == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            _appDbContext.students.Add(student);
            _appDbContext.SaveChanges();

            return Created();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Student student)
        {
            if (student == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = _appDbContext.students
                .FirstOrDefault(e => e.Id == id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.FirstName = student.FirstName;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.Date = student.Date;
            existingStudent.CLassRoomId = student.CLassRoomId;

            _appDbContext.SaveChanges();

            return Ok(existingStudent);
        }

        [HttpPatch("{id:int}")]
        public ActionResult Patch(int id, Student student)
        {
            if (student == null)
                return BadRequest();

            var existingStudent = _appDbContext.students
                .FirstOrDefault(e => e.Id == id);

            if (existingStudent == null)
                return NotFound();

            if (!string.IsNullOrEmpty(student.Name))
                existingStudent.Name = student.Name;

            if (!string.IsNullOrEmpty(student.FirstName))
                existingStudent.FirstName = student.FirstName;

            if (!string.IsNullOrEmpty(student.Email))
                existingStudent.Email = student.Email;

            if (!string.IsNullOrEmpty(student.Phone))
                existingStudent.Phone = student.Phone;

            if (student.Date != default)
                existingStudent.Date = student.Date;

            if (student.CLassRoomId != 0)
                existingStudent.CLassRoomId = student.CLassRoomId;

            _appDbContext.SaveChanges();

            return Ok(existingStudent);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var student = _appDbContext.students
                .FirstOrDefault(e => e.Id == id);

            if (student == null)
                return NotFound();

            _appDbContext.students.Remove(student);
            _appDbContext.SaveChanges();

            return Ok(student);
        }
    }
}
