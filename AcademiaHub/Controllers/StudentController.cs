using DatabaseAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace AcademiaHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;

        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAllStudentDetails")]
        public async Task<IActionResult> GetAllStudentDetails()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("GetStudentDetailsById/{id}")]
        public async Task<IActionResult> GetStudentDetailsById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [Route("AddStudentDetails")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentDetailsById), new { id = student.EnrollmentNo }, student);
        }

        [HttpPut("UpdateStudentDetailsById/{id}")]
        public async Task<IActionResult> UpdateStudentDetailsById(int id, [FromBody] Student student)
        {
            if (id != student.EnrollmentNo)
            {
                return BadRequest();
            }
            await _studentService.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpDelete("DeleteStudentDetailsById/{id}")]

        public async Task<IActionResult> DeleteStudentById(int id)
        {
            await _studentService.DeleteStudentByIdAsync(id);
            return NoContent();
        }
    }
}
