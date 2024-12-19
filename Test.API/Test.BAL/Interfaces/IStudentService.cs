using Test.BAL.DTOs;
using Test.DAL.Models;

namespace Test.BAL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int studentId);
        Task<IEnumerable<StudentWithCoursesDto>> GetStudentsWithCoursesAsync();
        Task<StudentWithCoursesDto> GetStudentWithCoursesByEmpIdAsync(int studentId);
        Task<SaveDbResult> AddStudentAsync(StudentDto studentDto);
        Task<SaveDbResult> UpdateStudentAsync(StudentDto studentDto);
        Task<SaveDbResult> DeleteStudentAsync(int studentId);
        Task<StudentDto> GetStudentByEmailAsync(string email);
    }
}
