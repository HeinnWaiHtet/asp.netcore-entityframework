using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.models;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: StudentController
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return _studentService.Get();
        }

        // GET: StudentController/Details/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.GetById(id);

            if (student == null)
            {
               return NotFound($"Student wit Id = {id} not found");
            }

            return student;
        }

        // GET: StudentController/Create
        [HttpPost]
        public ActionResult Create([FromBody] Student student)
        {
            _studentService.Create(student);
            return CreatedAtAction(nameof(Get), new {id = student.Id}, student);
        }

        // GET: StudentController/Edit/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Student student)
        {
            var existStudent = _studentService.GetById(id);

            if(existStudent == null)
            {
                return NotFound($"Student wit Id = {id} not found");
            }

            _studentService.Update(id, student);
            return NoContent();
        }

        // GET: StudentController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = _studentService.GetById(id);

            if(student == null)
            {
                return NotFound($"Student wit Id = {id} not found");
            }

            _studentService.Remove(student.Id);
            return Ok($"Student with Id = {id} deleted");
        }
    }
}
