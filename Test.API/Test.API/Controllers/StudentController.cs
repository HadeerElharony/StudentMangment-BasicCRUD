using Microsoft.AspNetCore.Mvc;
using Test.BAL.DTOs;
using Test.BAL.Interfaces;
using Test.DAL.Models;

namespace Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> testt2()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if (student == null)
                    return NotFound($"Student with ID {id} not found.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/student/with-courses
        [HttpGet]
        public async Task<IActionResult> GetStudentsWithCourses()
        {
            try
            {
                var students = await _studentService.GetStudentsWithCoursesAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
                return BadRequest("Student data is null.");

            try
            {
                var result = await _studentService.AddStudentAsync(studentDto);
                return Ok(new { Message = "Student added successfully", Result = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/student
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
                return BadRequest("Student data is null.");

            try
            {
                var result = await _studentService.UpdateStudentAsync(studentDto);
                return Ok(new { Message = "Student updated successfully", Result = result });
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var result = await _studentService.DeleteStudentAsync(id);
                return Ok(new { Message = "Student deleted successfully", Result = result });
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<StudentDto>> GetStudentByEmailAsync(string email)
        {
            var studentDto = await _studentService.GetStudentByEmailAsync(email);

            if (studentDto == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            return Ok(studentDto);
        }
    }
}

