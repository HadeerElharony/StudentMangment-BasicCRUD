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
        /// <summary>
        /// Retrieves a list of all students.
        /// </summary>
        /// <returns>An action result containing a list of students.</returns>
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

        /// <summary>
        /// Retrieves the details of a student by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>An action result containing the student details or a 404 if not found.</returns>
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

        /// <summary>
        /// Retrieves a list of students along with their associated courses.
        /// </summary>
        /// <returns>An action result containing a list of students with courses.</returns>
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

        /// <summary>
        /// Adds a new student to the system.
        /// </summary>
        /// <param name="studentDto">The data of the student to add.</param>
        /// <returns>An action result with a success message or an error if the student data is null.</returns>
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

        /// <summary>
        /// Updates an existing student's information.
        /// </summary>
        /// <param name="studentDto">The updated student data.</param>
        /// <returns>An action result with a success message or an error if not found or if the data is invalid.</returns>
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

        /// <summary>
        /// Deletes a student from the system by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        /// <returns>An action result with a success message or an error if not found.</returns>
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

        /// <summary>
        /// Retrieves a student by their email address.
        /// </summary>
        /// <param name="email">The email address of the student to retrieve.</param>
        /// <returns>An action result containing the student details or a 404 if not found.</returns>
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

        /// <summary>
        /// Retrieves a student along with their courses by their ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve along with courses.</param>
        /// <returns>An action result containing the student and their courses or a 404 if not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentWithCoursesById(int id)
        {
            var studentWithCourses = await _studentService.GetStudentWithCoursesByEmpIdAsync(id);

            if (studentWithCourses == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            return Ok(studentWithCourses);
        }
    }
}

