using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quizone.DTOS;
using Quizone.Mapping;
using Quizone.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quizone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        protected readonly AppDbContext appDbContext;
        protected IMapper mapper;
        public TeacherController()
        {
            appDbContext = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<TeacherProfile>(), new LoggerFactory());

            mapper = config.CreateMapper();
        }

        [HttpGet]
        public ActionResult<TeacherDtos> GetAll()
        {
            var Teachers = appDbContext.teachers.Include(d => d.Department).ToList();

            if (Teachers == null || Teachers.Count == 0)
            {
                return NotFound("No Teachers Found");
            }

            var r = mapper.Map<List<TeacherDtos>>(Teachers);

            return Ok(r);
        }



        [HttpGet("{id:int}")]
        public ActionResult<TeacherDtos> GetById(int id)
        {
            var data = appDbContext.teachers.Include(d => d.Department).FirstOrDefault(x => x.Id == id);

            if (data == null) { return NotFound(); }

            var r = mapper.Map<TeacherDtos>(data);


            return Ok(r);
        }

        [HttpPost]
        public IActionResult Add(TeacherCreateDtos dto)
        {
            if (dto == null) { return BadRequest(); }

            var newTeacher = mapper.Map<Teacher>(dto);

            appDbContext.teachers.Add(newTeacher);
            appDbContext.SaveChanges();

            return Created();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, TeacherCreateDtos dto)
        {
            var data = appDbContext.teachers.FirstOrDefault(x => x.Id == id);

            if (data == null) { return NotFound(); }

            mapper.Map(dto, data); // يعمل تحديث مباشر من الـ DTO للـ Entity

            appDbContext.SaveChanges();

            return Ok(data);
        }




    }
}
