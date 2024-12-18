namespace Test.BAL.DTOs
{
    public class StudentWithCoursesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
