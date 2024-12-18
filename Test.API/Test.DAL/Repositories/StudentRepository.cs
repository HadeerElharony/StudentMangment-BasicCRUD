using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DAL.DbContext;
using Test.DAL.Entities;
using Test.DAL.Interfaces;

namespace Test.DAL.Repositories
{
    public class StudentRepository : GenericRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Student>> GetStudentsWithCoursesAsync()
        {
            return await _entity
                .Include(student => student.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
