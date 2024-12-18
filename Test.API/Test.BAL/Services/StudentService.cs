using AutoMapper;
using Test.BAL.DTOs;
using Test.BAL.Interfaces;
using Test.BAL.Mappers;
using Test.DAL.Entities;
using Test.DAL.Interfaces;
using Test.DAL.Models;

namespace Test.BAL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return AutoStaticMapper<Student, StudentDto>.MapList(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            return AutoStaticMapper<Student, StudentDto>.MapObject(student);
        }

        public async Task<IEnumerable<StudentWithCoursesDto>> GetStudentsWithCoursesAsync()
        {
            var students = await _studentRepository.GetStudentsWithCoursesAsync();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentWithCoursesDto>()
                    .ForMember(dest => dest.Courses, opt => opt.MapFrom(src =>
                        src.StudentCourses.Select(sc => new CourseDto
                        {
                            Id = sc.Course.CourseId,
                            CourseName = sc.Course.CourseName
                        }).ToList()));

                cfg.CreateMap<Course, CourseDto>(); // Optional if CourseDto mapping is simple
            });

            // Map using the custom MapListWithConfig method
            return AutoStaticMapper<Student, StudentWithCoursesDto>.MapListWithConfig(students.ToList(), config);
        }

        public async Task<SaveDbResult> AddStudentAsync(StudentDto studentDto)
        {
            var student = AutoStaticMapper<StudentDto, Student>.MapObject(studentDto);
            return await _studentRepository.AddAsync(student);
        }

        public async Task<SaveDbResult> UpdateStudentAsync(StudentDto studentDto)
        {
            var student = AutoStaticMapper<StudentDto, Student>.MapObject(studentDto);
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<SaveDbResult> DeleteStudentAsync(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                throw new KeyNotFoundException($"Student with ID {studentId} not found.");

            return await _studentRepository.DeleteAsync(student);
        }

        public async Task<StudentDto> GetStudentByEmailAsync(string email)
        {
            var students = await _studentRepository.FindAsync(student => student.Email == email);
            var student = students.FirstOrDefault();

            if (student == null)
            {
                // Handle the case where no student is found (return null or throw an exception)
                return null;
            }

            // Map the student entity to a StudentDto
            return AutoStaticMapper<Student, StudentDto>.MapObject(student);
        }
    }
}
