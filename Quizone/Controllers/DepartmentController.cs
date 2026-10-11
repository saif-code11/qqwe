using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizone.DTOS;
using Quizone.Models;

namespace Quizone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        protected readonly AppDbContext _context;

        public DepartmentController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _context.departments.ToList();

            if (departments == null || departments.Count == 0)
            {
                return NotFound("No Department Found");
            }

            var ListofDept = new List<DepartmentDto>();

            foreach (var D in departments)
            {
                var dept = new DepartmentDto
                {
                    Id = D.Id,
                    Name = D.Name,
                    Description = D.Description
                };

                ListofDept.Add(dept);
            }

            return Ok(ListofDept);
        }



        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var data = _context.departments.FirstOrDefault(x => x.Id == id);

            if (data == null) { return NotFound(); }


            var Deprt = new DepartmentDto
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description
            };

            return Ok(Deprt);
        }

        [HttpPost]
        public IActionResult Add(DepartmentCreateDto dto)
        {
            if (dto == null) { return BadRequest(); }

            var newdp = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.departments.Add(newdp);
            _context.SaveChanges();
            return Created();
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int id , DepartmentCreateDto dto)
        {
            var data = _context.departments.FirstOrDefault(x => x.Id == id);

            if (data == null) { return NotFound(); }

            data.Name = dto.Name;
            data.Description = dto.Description;

            _context.SaveChanges();

            return Ok();
        }



        
    }
}
