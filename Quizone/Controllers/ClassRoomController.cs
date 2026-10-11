using Microsoft.AspNetCore.Mvc;
using Quizone.DTOS;
using Quizone.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quizone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {

        protected readonly AppDbContext _context;

        public ClassRoomController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var classRoom = _context.classRooms.ToList();

            if (classRoom == null || classRoom.Count == 0)
            {
                return NotFound("No classRooms Found");
            }

            var ListofDept = new List<ClassRoomDtos>();

            foreach (var D in classRoom)
            {
                var dept = new ClassRoomDtos
                {
                    Id = D.Id,
                    name = D.Name,
                    Grade = D.GradeLevel

                };

                ListofDept.Add(dept);
            }

            return Ok(ListofDept);
        }



        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var data = _context.classRooms.FirstOrDefault(x => x.Id == id);

            if (data == null) { return NotFound(); }


            var Deprt = new ClassRoomDtos
            {
              Id= data.Id,
              name= data.Name,
              Grade = data.GradeLevel
            };

            return Ok(Deprt);
        }

        [HttpPost]
        public IActionResult Add(ClassRoomCreateDto dto)
        {



            if (dto == null) { return BadRequest(); }

            var newdp = new ClassRoom
            {
                Name = dto.name,
                GradeLevel = dto.Grade,
                Capacity = dto.Capacity
            };

            _context.classRooms.Add(newdp);
            _context.SaveChanges();
            return Created();
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int id, ClassRoomCreateDto dto)
        {
            var data = _context.classRooms.FirstOrDefault(x => x.Id == id);

            if (data == null) { return NotFound(); }

            data.Name = dto.name;
            data.GradeLevel = dto.Grade;
            data.Capacity = dto.Capacity;

            _context.SaveChanges();

            return Ok();
        }


    }
}
